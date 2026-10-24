using Microsoft.FluentUI.AspNetCore.Components;
using c5m._2d6Dungeon.web.Components;
using c5m._2d6Dungeon;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
    
builder.Services.AddFluentUIComponents(config =>
{
    // Fluent UI v4 applied a 10px gap to every FluentStack; v5 applies none. Keep the v4 spacing.
    config.DefaultValues.For<FluentStack>().Set(p => p.HorizontalGap, "10px");
    config.DefaultValues.For<FluentStack>().Set(p => p.VerticalGap, "10px");
});

builder.Services.AddHttpClient<D6Service>(client =>
{
    client.BaseAddress = new("https+http://dab");
});
builder.Services.AddScoped<ID6Service>(sp => sp.GetRequiredService<D6Service>());

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
