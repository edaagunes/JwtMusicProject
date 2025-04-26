using FluentValidation;
using JwtMusic.DtoLayer.BannerDtos;
using JwtMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.BusinessLayer.Validations.BannerValidations
{
	public class CreateBannerValidator : AbstractValidator<CreateBannerDto>
	{
		public CreateBannerValidator()
		{
			RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez")
								.MinimumLength(3).WithMessage("Minimum 3 karakter giriniz")
								.MaximumLength(50).WithMessage("Maksimum 50 karakter giriniz");

			RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Alt Başlık boş geçilemez")
								.MinimumLength(3).WithMessage("Minimum 3 karakter giriniz")
								.MaximumLength(50).WithMessage("Maksimum 50 karakter giriniz");

			RuleFor(x => x.Description).NotEmpty().WithMessage("Başlık boş geçilemez")
								.MinimumLength(10).WithMessage("Minimum 10 karakter giriniz")
								.MaximumLength(100).WithMessage("Maksimum 100 karakter giriniz");
		}
	}
}
