using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.DtoLayer.SongDtos
{
	public class CreateSongDto
	{
		public string SongName { get; set; }
		public string Singer { get; set; }
		public IFormFile SongFile { get; set; }
	}
}
