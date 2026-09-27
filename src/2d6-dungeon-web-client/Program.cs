using Microsoft.FluentUI.AspNetCore.Components;
using c5m._2d6Dungeon.web.Components;
using c5m._2d6Dungeon;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
    
builder.Services.AddFluentUIComponents();

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
