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

builder.Services.AddIdentity<AppUser, AppRole>()
        .AddEntityFrameworkStores<ApplicationContext>()
        .AddDefaultTokenProviders();

builder.Services.AddScoped<UserManager<AppUser>>();

//builder.Services.AddIdentity<AppUser, AppRole>(opt =>
//{
//    opt.Password.RequireNonAlphanumeric = false;
//    opt.Password.RequireLowercase = false;
//    opt.Password.RequireUppercase = false;
//})
//    .AddRoleManager<RoleManager<AppRole>>()
//    .AddErrorDescriber<CustomIdentityErrorDescriber>()
//    .AddEntityFrameworkStores<ApplicationContext>()
//    .AddDefaultTokenProviders();



//builder.Services.ConfigureApplicationCookie(config =>
//{
//    config.LoginPath = new PathString("/Admin/Auth/Login");
//    config.LogoutPath = new PathString("/Admin/Auth/Logout");
//    config.Cookie = new CookieBuilder
//    {
//        Name = "myCoreIdentity",
//        HttpOnly = true,
//        SameSite = SameSiteMode.Strict,
//        SecurePolicy = CookieSecurePolicy.SameAsRequest //Always //hem http den hem https den istek alýr canlýda Always yani https desteðini seç.
//    };
//    config.SlidingExpiration = true;
//    config.ExpireTimeSpan = TimeSpan.FromDays(7);
//    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
//});


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
