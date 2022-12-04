using BAL.IServices;
using BAL.Services;
using DAL;
using DAL.IRepos;
using DAL.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductServcie, ProductService>();
builder.Services.AddCors(p => p.AddPolicy("BlazorLab", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

}));

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(t =>
{
    t.Authority = "https://demo.duendesoftware.com";
    t.RequireHttpsMetadata = false;
    t.SaveToken = true;
    t.TokenValidationParameters = new()
    {
        ValidateIssuerSigningKey = false,
        ValidateAudience = false,
        ValidateIssuer = false,
    };
});

var app = builder.Build();
app.UseCors("BlazorLab");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers()
    .RequireAuthorization();

app.Run();

