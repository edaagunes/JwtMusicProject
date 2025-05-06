using System.ComponentModel.DataAnnotations;

namespace JwtMusic.WebUI.ViewModels
{
	public class UserLoginViewModel
	{
		[Required]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
