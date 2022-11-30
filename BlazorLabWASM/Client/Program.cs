using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorLabWASM.Client;
using BlazorLabWASM.Client.Services;
using BlazorLabWASM.Client.IServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7082") });
builder.Services.AddScoped<IProductServiceApi, ProductServiceApi>();

builder.Services.AddTelerikBlazor();


await builder.Build().RunAsync();

