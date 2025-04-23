using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.DtoLayer.BannerDtos
{
	public class CreateBannerDto
	{
		public string SubTitle { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
