using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.EntityLayer.Entities
{
	public class AppUser : IdentityUser<int>
	{
		public string FullName { get; set; }
		public int? PackageId { get; set; }
		public Package Package { get; set; }
	}
}
