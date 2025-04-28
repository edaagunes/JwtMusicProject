using FluentValidation;
using JwtMusic.DtoLayer.CountDownDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.BusinessLayer.Validations.CountDownValidations
{
	public class CreateCountDownValidator:AbstractValidator<CreateCountDownDto>
	{
		public CreateCountDownValidator()
		{
			RuleFor(x => x.Title)
			.NotEmpty().WithMessage("Başlık boş geçilemez.")
			.MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

			RuleFor(x => x.SubTitle)
				.NotEmpty().WithMessage("Alt Başlık boş geçilemez.")
				.MaximumLength(200).WithMessage("Alt Başlık en fazla 200 karakter olabilir.");

			RuleFor(x => x.Date)
				.NotEmpty().WithMessage("Tarih boş geçilemez")
				.GreaterThan(DateTime.Now).WithMessage("Tarih bugünden sonraki bir tarih olmalıdır.");
		}
	}
}
