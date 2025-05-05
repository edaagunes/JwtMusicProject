using FluentValidation;
using JwtMusic.DtoLayer.SongDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.BusinessLayer.Validations.SongValidations
{
	public class CreateSongValidator : AbstractValidator<CreateSongDto>
	{
		public CreateSongValidator()
		{
			RuleFor(x => x.SongName)
				.NotEmpty().WithMessage("Şarkı adı boş olamaz.")
				.Length(3, 100).WithMessage("Şarkı adı 3 ile 100 karakter arasında olmalıdır.");

			RuleFor(x => x.Singer)
				.NotEmpty().WithMessage("Şarkıcı adı boş olamaz.")
				.Length(3, 50).WithMessage("Şarkıcı adı 3 ile 50 karakter arasında olmalıdır.");

			RuleFor(x => x.SongUrl)
				.NotEmpty().WithMessage("Şarkı URL'si boş olamaz.");
		}
	}
}
