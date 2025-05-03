using FluentValidation.AspNetCore;
using JwtMusic.BusinessLayer.Container;
using JwtMusic.BusinessLayer.Mapping;
using JwtMusic.BusinessLayer.Validations.BannerValidations;
using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.DataAccessLayer.Context;
using JwtMusic.DataAccessLayer.Repositories;
using JwtMusic.EntityLayer.Entities;
using JwtMusic.WebUI.Helpers;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
	.AddFluentValidation(config =>
	{
		config.RegisterValidatorsFromAssemblyContaining<CreateBannerValidator>();
		config.RegisterValidatorsFromAssemblyContaining<UpdateBannerValidator>();
	});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<JwtMusicContext>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<JwtMusicContext>();

var app = builder.Build();

// ⬇️ Roller seed ediliyor
using (var scope = app.Services.CreateScope())
{
	var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
	await SeedRoles.InitializeAsync(roleManager);

	var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
	await SeedUsers.CreateAdminUserAsync(userManager);
}

builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));

builder.Services.ContainerDependencies();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

app.UseRequestLocalization();

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
