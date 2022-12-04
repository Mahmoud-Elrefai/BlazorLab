using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorLabWASM.Client;
using BlazorLabWASM.Client.Services;
using BlazorLabWASM.Client.IServices;
using BlazorWasm.Client.BFF;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// authentication state plumbing
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, BffAuthenticationStateProvider>();

// HTTP client configuration
builder.Services.AddTransient<AntiforgeryHandler>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpClient("backend", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<AntiforgeryHandler>();

builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("backend"));

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7082") });

builder.Services.AddScoped<IProductServiceApi, ProductServiceApi>();

builder.Services.AddTelerikBlazor();

await builder.Build().RunAsync();

