using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.EntityLayer.Entities
{
	public class Banner
	{
		public int BannerId { get; set; }
		public string SubTitle {  get; set; }
		public string Title {  get; set; }
		public string Description { get; set; }

	}
}
