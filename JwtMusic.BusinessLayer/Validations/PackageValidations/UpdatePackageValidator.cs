using FluentValidation;
using JwtMusic.DtoLayer.PackageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.BusinessLayer.Validations.PackageValidations
{
	public class UpdatePackageValidator : AbstractValidator<UpdatePackageDto>
	{
		public UpdatePackageValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Paket adı boş geçilemez")
								.MinimumLength(3).WithMessage("Minimum 3 karakter giriniz")
								.MaximumLength(50).WithMessage("Maksimum 50 karakter giriniz");
		}
	}
}
