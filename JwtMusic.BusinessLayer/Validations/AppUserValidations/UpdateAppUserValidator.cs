using FluentValidation;
using JwtMusic.DtoLayer.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.BusinessLayer.Validations.AppUserValidations
{
	public class UpdateAppUserValidator : AbstractValidator<UpdateAppUserDto>
	{
		public UpdateAppUserValidator()
		{
			RuleFor(x => x.FullName)
			.NotEmpty().WithMessage("Ad Soyad alanı boş geçilemez.")
			.MinimumLength(3).WithMessage("Ad Soyad en az 3 karakter olmalıdır.")
			.MaximumLength(50).WithMessage("Ad Soyad en fazla 50 karakter olabilir.");

			RuleFor(x => x.PackageId)
				.NotEmpty().WithMessage("Lütfen bir paket seçiniz.")
				.GreaterThan(0).WithMessage("Geçerli bir paket seçmelisiniz.");
		}
	}
}
