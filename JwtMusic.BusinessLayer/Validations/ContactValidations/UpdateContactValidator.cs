using FluentValidation;
using JwtMusic.DtoLayer.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.BusinessLayer.Validations.ContactValidations
{
	public class UpdateContactValidator : AbstractValidator<UpdateContactDto>
	{
		public UpdateContactValidator()
		{
			RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon boş geçilemez")
								 .Matches(@"^05\d{9}$").WithMessage("Telefon numarası 05 ile başlamalı ve toplam 11 hane olmalıdır.");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresi boş geçilemez")
								 .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
		}
	}
}
