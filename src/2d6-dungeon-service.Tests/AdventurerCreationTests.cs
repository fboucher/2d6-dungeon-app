using System.Net;
using System.Text;
using c5m._2d6Dungeon;
using c5m._2d6Dungeon.Game;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace _2d6_dungeon_service.Tests;

/// <summary>
/// Tests for adventurer creation validation and for loading adventurers with bad armour data (issue #246).
///
/// Verifies that:
/// - An adventurer with a null or missing armour piece is rejected before anything is sent to the database
/// - A complete adventurer passes validation and is saved
/// - A saved adventurer holding null armour entries loads without them, so the Play page can render
/// </summary>
public class AdventurerCreationTests
{
    private static Adventurer CreateValidAdventurer()
    {
        return new Adventurer("Valiant Hero")
        {
            Weapon = new Weapon { Id = 1, Name = "Sword" },
            WeaponManoeuvres = new List<WeaponManoeuvre> { new WeaponManoeuvre { Id = 1, Description = "Slash" } },
            ArmourPieces = new List<ArmourPiece> { new ArmourPiece { Id = 1, Name = "Leather Cap", DiceSet = "1-2" } },
            MagicScrolls = new List<MagicScroll> { new MagicScroll { Id = 1, ScrollType = "Fire", Description = "Fireball" } },
        };
    }

    private static (D6Service service, StubHttpMessageHandler handler) CreateService()
    {
        var handler = new StubHttpMessageHandler(
            "{\"value\":[{\"id\":7,\"name\":\"Valiant Hero\",\"level\":1,\"xp\":0,\"serialiazedObj\":\"\"}]}");
        var httpClient = new HttpClient(handler) { BaseAddress = new Uri("http://localhost/") };
        return (new D6Service(httpClient, NullLogger<D6Service>.Instance), handler);
    }

    [Fact]
    public async Task AdventurerCreate_WithNullArmourPiece_ShouldBeRejected()
    {
        // Arrange
        var (service, handler) = CreateService();
        var adventurer = CreateValidAdventurer();
        adventurer.ArmourPieces = new List<ArmourPiece> { null! };

        // Act & Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => service.AdventurerCreate(adventurer));
        Assert.Contains("armour", ex.Message, StringComparison.OrdinalIgnoreCase);
        Assert.Equal(0, handler.RequestCount);
    }

    [Fact]
    public async Task AdventurerCreate_WithoutArmourPiece_ShouldBeRejected()
    {
        // Arrange
        var (service, handler) = CreateService();
        var adventurer = CreateValidAdventurer();
        adventurer.ArmourPieces = new List<ArmourPiece>();

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => service.AdventurerCreate(adventurer));
        Assert.Equal(0, handler.RequestCount);
    }

    [Fact]
    public async Task AdventurerCreate_WithValidAdventurer_ShouldSave()
    {
        // Arrange
        var (service, handler) = CreateService();
        var adventurer = CreateValidAdventurer();

        // Act
        var id = await service.AdventurerCreate(adventurer);

        // Assert
        Assert.Empty(adventurer.GetCreationErrors());
        Assert.Equal(7, id);
        Assert.Equal(1, handler.RequestCount);
    }

    [Fact]
    public void GetCreationErrors_WithMissingSelections_ShouldListEachProblem()
    {
        // Arrange
        var adventurer = new Adventurer();

        // Act
        var errors = adventurer.GetCreationErrors();

        // Assert
        Assert.Equal(5, errors.Count);
    }

    [Fact]
    public void Constructor_WithSavedNullArmourPiece_ShouldDropIt()
    {
        // Arrange
        var saved = CreateValidAdventurer();
        saved.ArmourPieces = new List<ArmourPiece> { null!, new ArmourPiece { Id = 2, Name = "Shield", DiceSet = "6" } };
        var preview = new AdventurerDTO(saved);

        // Act
        var loaded = new Adventurer(preview);

        // Assert
        Assert.NotNull(loaded.ArmourPieces);
        Assert.DoesNotContain(null, loaded.ArmourPieces!);
        Assert.Single(loaded.ArmourPieces!);
        Assert.Equal("Shield", loaded.ArmourPieces![0].Name);
    }

    private class StubHttpMessageHandler : HttpMessageHandler
    {
        private readonly string responseJson;
        public int RequestCount { get; private set; }

        public StubHttpMessageHandler(string responseJson)
        {
            this.responseJson = responseJson;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            RequestCount++;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
            });
        }
    }
}
