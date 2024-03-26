using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazingTrails.Client;
using BlazingTrails.Shared.Features.ManageTrails;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSassCompiler();
builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining<TrailDTO>());

var app = builder.Build();

await app.RunAsync();
