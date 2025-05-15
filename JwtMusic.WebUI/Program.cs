using FluentValidation.AspNetCore;
using JwtMusic.BusinessLayer.Container;
using JwtMusic.BusinessLayer.Mapping;
using JwtMusic.BusinessLayer.Validations.BannerValidations;
using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.DataAccessLayer.Context;
using JwtMusic.DataAccessLayer.Repositories;
using JwtMusic.EntityLayer.Entities;
using JwtMusic.WebUI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
	var policy = new AuthorizationPolicyBuilder()
					.RequireAuthenticatedUser()
					.Build();
	options.Filters.Add(new AuthorizeFilter(policy));
})
.AddFluentValidation(config =>
{
	config.RegisterValidatorsFromAssemblyContaining<CreateBannerValidator>();
	config.RegisterValidatorsFromAssemblyContaining<UpdateBannerValidator>();
});

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = false,
		ValidateAudience = false,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("JwtMusicProject+*010203JWTMUSIC01+*..020304JwtMusicProject"))
	};
});


// Add services to the container.

builder.Services.AddDbContext<JwtMusicContext>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<JwtMusicContext>();

builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));

builder.Services.AddScoped<JwtTokenHelper>();

builder.Services.ContainerDependencies();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Admin/Login/Index"; 
});

var app = builder.Build();

// ⬇️ Roller seed ediliyor
using (var scope = app.Services.CreateScope())
{
	var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
	await SeedRoles.InitializeAsync(roleManager);

	var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
	await SeedUsers.CreateAdminUserAsync(userManager);
	await SeedUsers.CreateMemberUserAsync(userManager);
}

app.UseRequestLocalization();

// Error Page - 403
app.UseStatusCodePagesWithReExecute("/Admin/ErrorPage/AccessDenied", "?code={0}");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "areas",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
});

await app.RunAsync();
