using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.DtoLayer.PackageDtos
{
	public class CreatePackageDto
	{
		public string Name { get; set; }
		public List<int> SongIds { get; set; } = new List<int>();
	}
}
