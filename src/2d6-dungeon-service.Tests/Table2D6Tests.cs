using System.Text.Json;
using c5m._2d6Dungeon;
using c5m._2d6Dungeon.domain;
using Microsoft.Extensions.Logging.Abstractions;

namespace _2d6_dungeon_service.Tests;

/// <summary>
/// Tests for SimpleTable2D6Row numeric roll sort key parsing and ordering,
/// covering single numbers (1..12), 2D6 combination rolls (1-1..6-6),
/// reverse sorting, and all CSV table files in the data directory.
/// </summary>
public class Table2D6Tests
{
    [Fact]
    public void RollSortKey_PlainNumbersUpTo12_SortsNumericallyAscendingAndDescending()
    {
        // Arrange: start in lexicographic order where "10", "11", "12" precede "2"
        var rows = new List<SimpleTable2D6Row>
        {
            new() { Roll = "1", Description = "One" },
            new() { Roll = "10", Description = "Ten" },
            new() { Roll = "11", Description = "Eleven" },
            new() { Roll = "12", Description = "Twelve" },
            new() { Roll = "2", Description = "Two" },
            new() { Roll = "3", Description = "Three" },
            new() { Roll = "4", Description = "Four" },
            new() { Roll = "5", Description = "Five" },
            new() { Roll = "6", Description = "Six" },
            new() { Roll = "7", Description = "Seven" },
            new() { Roll = "8", Description = "Eight" },
            new() { Roll = "9", Description = "Nine" }
        };

        var expectedAscending = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
        var expectedDescending = expectedAscending.Reverse().ToArray();

        // Act
        var ascending = rows.AsQueryable().OrderBy(r => r.RollSortKey).Select(r => r.Roll).ToArray();
        var descending = rows.AsQueryable().OrderByDescending(r => r.RollSortKey).Select(r => r.Roll).ToArray();

        // Assert
        Assert.Equal(expectedAscending, ascending);
        Assert.Equal(expectedDescending, descending);
    }

    [Fact]
    public void RollSortKey_CombinationRolls_SortsByPrimaryThenSecondaryAscendingAndDescending()
    {
        // Arrange
        var expectedAscending = new List<string>();
        for (var primary = 1; primary <= 6; primary++)
        {
            for (var secondary = 1; secondary <= 6; secondary++)
            {
                expectedAscending.Add($"{primary}-{secondary}");
            }
        }

        // Reverse-ordered input to verify sorting reconstructs full 1-1 .. 6-6 sequence
        var rows = expectedAscending
            .AsEnumerable()
            .Reverse()
            .Select(roll => new SimpleTable2D6Row { Roll = roll, Description = $"Desc {roll}" })
            .ToList();

        var expectedDescending = expectedAscending.AsEnumerable().Reverse().ToArray();

        // Act
        var ascending = rows.AsQueryable().OrderBy(r => r.RollSortKey).Select(r => r.Roll).ToArray();
        var descending = rows.AsQueryable().OrderByDescending(r => r.RollSortKey).Select(r => r.Roll).ToArray();

        // Assert
        Assert.Equal(expectedAscending, ascending);
        Assert.Equal(expectedDescending, descending);
    }

    [Fact]
    public void SimpleTable2D6Row_JsonSerialization_DoesNotChangeWireShape()
    {
        // Arrange
        var row = new SimpleTable2D6Row { Roll = "10", Description = "Test item" };

        // Act
        var json = JsonSerializer.Serialize(row);
        using var doc = JsonDocument.Parse(json);
        var propertyNames = doc.RootElement.EnumerateObject().Select(p => p.Name).ToArray();

        // Assert
        Assert.Equal(new[] { "Roll", "Description" }, propertyNames);
    }

    [Fact]
    public async Task AllCsvTables_LoadAndSortAscendingAndDescendingWithoutThrowing()
    {
        // Arrange
        using var httpClient = new HttpClient();
        var service = new D6Service(httpClient, NullLogger<D6Service>.Instance);
        var dataDirectory = Path.Combine(AppContext.BaseDirectory, "data");
        var csvFiles = Directory.GetFiles(dataDirectory, "*.csv");

        Assert.NotEmpty(csvFiles);

        SimpleTable2D6? plainNumberTable = null;
        SimpleTable2D6? combinationRollTable = null;

        // Act & Assert
        foreach (var csvFile in csvFiles)
        {
            var tableCode = Path.GetFileNameWithoutExtension(csvFile);
            var table = await service.GetTableData(tableCode);

            Assert.NotNull(table);
            Assert.NotEmpty(table.Rows);

            var asc = table.Rows.AsQueryable().OrderBy(r => r.RollSortKey).Select(r => r.Roll).ToArray();
            var desc = table.Rows.AsQueryable().OrderByDescending(r => r.RollSortKey).Select(r => r.Roll).ToArray();

            Assert.Equal(asc.Reverse(), desc);

            if (tableCode == "bst1")
            {
                plainNumberTable = table;
            }
            else if (tableCode == "iaut1")
            {
                combinationRollTable = table;
            }
        }

        // Spot-check plain-number table (2..12)
        Assert.NotNull(plainNumberTable);
        var bstAscending = plainNumberTable.Rows.AsQueryable().OrderBy(r => r.RollSortKey).Select(r => r.Roll).ToArray();
        Assert.Equal(new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" }, bstAscending);

        // Spot-check combination-roll table (1-1..6-6)
        Assert.NotNull(combinationRollTable);
        var iautAscending = combinationRollTable.Rows.AsQueryable().OrderBy(r => r.RollSortKey).Select(r => r.Roll).ToArray();
        Assert.Equal("1-1", iautAscending.First());
        Assert.Equal("1-6", iautAscending[5]);
        Assert.Equal("2-1", iautAscending[6]);
        Assert.Equal("6-6", iautAscending.Last());
    }
}
