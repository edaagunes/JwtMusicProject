using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.DtoLayer.ContactDtos
{
	public class UpdateContactDto
	{
		public int ContactId { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
	}
}
