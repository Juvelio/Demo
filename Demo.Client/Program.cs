using CurrieTechnologies.Razor.SweetAlert2;
using Demo.Client;
using Demo.Client.Auth;
using Demo.Client.Repositorios;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ProveedorAutenticacionPrueba>();

builder.Services.AddScoped<GeneroRepositorio>();
builder.Services.AddSweetAlert2();


await builder.Build().RunAsync();
