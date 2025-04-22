using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.EntityLayer.Entities
{
	public class Contact
	{
		public int ContactId { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
	}
}
