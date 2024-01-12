using IdendtityCore.Context;
using IdendtityCore.Entity;
using IdendtityCore.Extensionss;
using Microsoft.AspNetCore.Identity;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.LoadDataLayerExtension(builder.Configuration);

//builder.Services.AddIdentity<AppUser, AppRole>()
//        .AddEntityFrameworkStores<ApplicationContext>()
//        .AddDefaultTokenProviders();

//builder.Services.AddScoped<UserManager<AppUser>>();

//builder.Services.AddScoped<RoleManager<IdentityRole>>();

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<UserManager<AppUser>>();
builder.Services.AddScoped<RoleManager<AppRole>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();// UseAuthorization altta olmalý

app.MapControllers();

app.Run();
