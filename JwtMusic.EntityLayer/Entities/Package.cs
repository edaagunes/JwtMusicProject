using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.EntityLayer.Entities
{
	public class Package
	{
		public int PackageId { get; set; }
		public string Name { get; set; }

		public ICollection<Song> Songs { get; set; }
		public ICollection<AppUser> Users { get; set; }
	}
}
