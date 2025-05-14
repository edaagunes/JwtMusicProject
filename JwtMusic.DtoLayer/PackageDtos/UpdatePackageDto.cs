using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.DtoLayer.PackageDtos
{
	public class UpdatePackageDto
	{
		public int PackageId { get; set; }
		public List<int> SongIds { get; set; }
		public string Name { get; set; }
		public List<string> CurrentSongNames { get; set; } = new List<string>();
	}
}
