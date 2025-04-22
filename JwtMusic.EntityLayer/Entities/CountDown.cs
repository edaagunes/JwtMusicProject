using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.EntityLayer.Entities
{
	public class CountDown
	{
		public int CountDownId { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public DateTime Date { get; set; }
	}
}
