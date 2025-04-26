using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Resources;
using JwtMusic.BusinessLayer.Container;
using JwtMusic.BusinessLayer.Mapping;
using JwtMusic.BusinessLayer.Validations.BannerValidations;
using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.DataAccessLayer.Context;
using JwtMusic.DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

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

builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));

builder.Services.ContainerDependencies();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();

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

app.Run();
