using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace JwtMusic.WebUI.Helpers
{
	public static class SeedRoles
	{
		public static async Task InitializeAsync(RoleManager<AppRole> roleManager)
		{
			string[] roles = { "Admin", "Member", "User" };

			foreach (var role in roles)
			{
				if (!await roleManager.RoleExistsAsync(role))
				{
					await roleManager.CreateAsync(new AppRole { Name = role });
				}
			}
		}
	}
}
