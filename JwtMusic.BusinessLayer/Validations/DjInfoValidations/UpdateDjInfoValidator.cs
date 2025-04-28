using FluentValidation;
using JwtMusic.DtoLayer.DjInfoDtos;
using JwtMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.BusinessLayer.Validations.DjInfoValidations
{
	public class UpdateDjInfoValidator : AbstractValidator<UpdateDjInfoDto>
	{
		public UpdateDjInfoValidator()
		{
			RuleFor(x => x.Name)
			.NotEmpty().WithMessage("DJ ismi boş geçilemez.")
			.MaximumLength(100).WithMessage("DJ ismi en fazla 100 karakter olabilir.");

			RuleFor(x => x.Description)
				.NotEmpty().WithMessage("Açıklama boş geçilemez.")
				.MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
		}
	}
}
