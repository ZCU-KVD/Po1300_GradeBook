using GradeBook.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextFactory<GradeBook.Data.SkolaDbContext>(option =>
{
	option.UseSqlite(connectionString);
	option.UseLazyLoadingProxies();
});

builder.Services.AddScoped<GradeBook.Services.SkolaService>();


// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var skolaService = scope.ServiceProvider.GetRequiredService<GradeBook.Services.SkolaService>();
	await skolaService.InicializaceAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
