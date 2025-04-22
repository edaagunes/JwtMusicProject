using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.EntityLayer.Entities
{
	public class Event
	{
		public int EventId { get; set; }
		public string ImageUrl { get; set; }
		public DateTime Date { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
	}
}
