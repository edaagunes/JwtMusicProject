using FluentValidation;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.BusinessLayer.Concrete;
using JwtMusic.BusinessLayer.Validations.BannerValidations;
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

			// Validators
			services.AddValidatorsFromAssemblyContaining<CreateBannerValidator>();
			services.AddValidatorsFromAssemblyContaining<UpdateBannerValidator>();

		}
	}
}
