using FluentValidation;
using JwtMusic.DtoLayer.SongDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.BusinessLayer.Validations.SongValidations
{
	public class UpdateSongValidator : AbstractValidator<UpdateSongDto>
	{
		public UpdateSongValidator()
		{
			RuleFor(x => x.SongName)
				.NotEmpty().WithMessage("Şarkı adı boş olamaz.")
				.Length(3, 100).WithMessage("Şarkı adı 3 ile 100 karakter arasında olmalıdır.");

			RuleFor(x => x.Singer)
				.NotEmpty().WithMessage("Şarkıcı adı boş olamaz.")
				.Length(3, 50).WithMessage("Şarkıcı adı 3 ile 50 karakter arasında olmalıdır.");

			// Eğer mevcut bir SongUrl yoksa (yani ilk ekleme ise) dosya zorunlu olsun
			When(x => string.IsNullOrEmpty(x.SongUrl), () =>
			{
				RuleFor(x => x.SongFile)
					.NotEmpty().WithMessage("Şarkı dosyası yüklenmeli.");
			});
		}
	}
}
