using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.DtoLayer.AppUserDtos
{
	public class ResultAppUserDto
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public int? PackageId { get; set; }
		public string PackageName { get; set; }
	}
}
