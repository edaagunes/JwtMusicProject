﻿using FluentValidation;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.BusinessLayer.Concrete;
using JwtMusic.BusinessLayer.Validations.AppUserValidations;
using JwtMusic.BusinessLayer.Validations.BannerValidations;
using JwtMusic.BusinessLayer.Validations.ContactValidations;
using JwtMusic.BusinessLayer.Validations.CountDownValidations;
using JwtMusic.BusinessLayer.Validations.DjInfoValidations;
using JwtMusic.BusinessLayer.Validations.EventValidations;
using JwtMusic.BusinessLayer.Validations.PackageValidations;
using JwtMusic.BusinessLayer.Validations.SongValidations;
using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace JwtMusic.BusinessLayer.Container
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection services)
		{
			services.AddScoped<IBannerService, BannerManager>();
			services.AddScoped<IBannerDal, EfBannerDal>();

			services.AddScoped<IContactService, ContactManager>();
			services.AddScoped<IContactDal, EfContactDal>();

			services.AddScoped<ICountDownService, CountDownManager>();
			services.AddScoped<ICountDownDal, EfCountDownDal>();

			services.AddScoped<IDjInfoService, DjInfoManager>();
			services.AddScoped<IDjInfoDal, EfDjInfoDal>();

			services.AddScoped<IEventService, EventManager>();
			services.AddScoped<IEventDal, EfEventDal>();

			services.AddScoped<ISongService, SongManager>();
			services.AddScoped<ISongDal, EfSongDal>();

			services.AddScoped<IPackageService, PackageManager>();
			services.AddScoped<IPackageDal, EfPackageDal>();

			services.AddScoped<IAppUserService, AppUserManager>();
			services.AddScoped<IAppUserDal, EfAppUserDal>();

			// Validators
			services.AddValidatorsFromAssemblyContaining<CreateBannerValidator>();
			services.AddValidatorsFromAssemblyContaining<UpdateBannerValidator>();

			services.AddValidatorsFromAssemblyContaining<CreateContactValidator>();
			services.AddValidatorsFromAssemblyContaining<UpdateContactValidator>();
			
			services.AddValidatorsFromAssemblyContaining<CreateCountDownValidator>();
			services.AddValidatorsFromAssemblyContaining<UpdateCountDownValidator>();

			services.AddValidatorsFromAssemblyContaining<CreateDjInfoValidator>();
			services.AddValidatorsFromAssemblyContaining<UpdateDjInfoValidator>();

			services.AddValidatorsFromAssemblyContaining<CreateEventValidator>();
			services.AddValidatorsFromAssemblyContaining<UpdateEventValidator>();

			services.AddValidatorsFromAssemblyContaining<CreateSongValidator>();
			services.AddValidatorsFromAssemblyContaining<UpdateSongValidator>();

			services.AddValidatorsFromAssemblyContaining<CreatePackageValidator>();
			services.AddValidatorsFromAssemblyContaining<UpdatePackageValidator>();

			services.AddValidatorsFromAssemblyContaining<UpdateAppUserValidator>();
		}
	}
}
