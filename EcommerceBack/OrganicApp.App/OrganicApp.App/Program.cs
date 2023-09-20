using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrganicApp.Core.Entities;
using OrganicApp.Data.Contexts;
using OrganicApp.Data.UniteOfWork;
using OrganicApp.Service.Extensions;
using OrganicApp.Service.Services.Interface;
using OrganicApp.Service.Services;
using OrganicApp.Service.Utilities.CustomDescriber;

var builder = WebApplication.CreateBuilder(args);

//Extension
builder.Services.AddValidation();
builder.Services.AddServices();


builder.Services.AddControllersWithViews();

builder.Services.AddFluentValidationAutoValidation();


builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddScoped<ISocialService, SocialService>();
builder.Services.AddScoped<ISubscribeService, SubscribeService>();


#region Identity

builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;  
    opt.Password.RequireLowercase = true;       
    opt.Password.RequireUppercase = true;       
    opt.Password.RequiredLength = 4;            
    opt.Password.RequireDigit = false;

    opt.User.RequireUniqueEmail = true;

    opt.SignIn.RequireConfirmedEmail = true;
    opt.SignIn.RequireConfirmedAccount = false;

    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); 
    opt.Lockout.MaxFailedAccessAttempts = 3;                      

}).AddErrorDescriber<CustomErrorDescriber>().AddEntityFrameworkStores<OrganicAppDbContext>().AddDefaultTokenProviders();

#endregion

#region Cookie

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "AshionIdentity";
    opt.LoginPath = new PathString("/Account/Login");
    opt.AccessDeniedPath = new PathString("/Account/AccessDenied");

});

#endregion

#region Context

builder.Services.AddDbContext<OrganicAppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]);
});

#endregion

builder.Services.AddScoped<IUow, Uow>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Default2",
        pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
        );
    endpoints.MapControllerRoute(
        name: "Default",
        pattern: "{controller=Home}/{action=HomePage}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
});

app.Run();


