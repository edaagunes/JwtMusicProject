using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace JwtMusic.WebUI.Helpers
{
	public static class SeedUsers
	{
		public static async Task CreateAdminUserAsync(UserManager<AppUser> userManager)
		{
			var admin = await userManager.FindByEmailAsync("admin@example.com");
			if (admin == null)
			{
				var user = new AppUser
				{
					UserName = "admin",
					Email = "admin@example.com",
					FullName = "Admin",
					EmailConfirmed = true
				};

				var result = await userManager.CreateAsync(user, "Admin123!");
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, "Admin");
				}
			}
		}
	}
}

