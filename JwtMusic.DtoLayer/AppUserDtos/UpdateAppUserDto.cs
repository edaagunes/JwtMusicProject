using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.DtoLayer.AppUserDtos
{
	public class UpdateAppUserDto
	{
		public string FullName { get; set; }
		public int? PackageId { get; set; }
	}
}
