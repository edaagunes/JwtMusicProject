using FluentValidation;
using JwtMusic.DtoLayer.EventDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.BusinessLayer.Validations.EventValidations
{
	public class CreateEventValidator : AbstractValidator<CreateEventDto>
	{
		public CreateEventValidator()
		{
			RuleFor(x => x.ImageUrl)
			.NotEmpty().WithMessage("Görsel URL'si boş geçilemez.")
			.MaximumLength(300).WithMessage("Görsel URL'si en fazla 300 karakter olabilir.")
			.Must(url => url.EndsWith(".jpg") || url.EndsWith(".png") || url.EndsWith(".jpeg"))
				.WithMessage("Görsel URL'si .jpg, .jpeg veya .png uzantılı olmalıdır.");

			RuleFor(x => x.Date)
				.GreaterThan(DateTime.Now).WithMessage("Tarih bugünden sonraki bir tarih olmalıdır.");

			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Etkinlik ismi boş geçilemez.")
				.MaximumLength(100).WithMessage("Etkinlik ismi en fazla 100 karakter olabilir.");

			RuleFor(x => x.Location)
				.NotEmpty().WithMessage("Etkinlik yeri boş geçilemez.")
				.MaximumLength(150).WithMessage("Etkinlik yeri en fazla 150 karakter olabilir.");
		}
	}
}
