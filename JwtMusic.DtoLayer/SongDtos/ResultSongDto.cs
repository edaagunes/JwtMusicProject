using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.DtoLayer.SongDtos
{
	public class ResultSongDto
	{
		public int SongId { get; set; }
		public string SongName { get; set; }
		public string Singer { get; set; }
		public string SongUrl { get; set; }
	}
}
