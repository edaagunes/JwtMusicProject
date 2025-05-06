using System.ComponentModel.DataAnnotations;

namespace JwtMusic.WebUI.ViewModels
{
	public class UserRegisterViewModel
	{
		[Required]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		public int PackageId { get; set; }

		[Required]
		public string FullName { get; set; }
	}
}
