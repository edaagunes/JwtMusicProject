using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.SongDtos;
using JwtMusic.WebUI.Helpers;

namespace JwtMusic.WebUI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class SongAccessController : ControllerBase
	{
		private readonly IAppUserService _appUserService;
		private readonly ISongService _songService;
		private readonly IMapper _mapper;
		private readonly JwtTokenHelper _jwtTokenHelper;

		public SongAccessController(IAppUserService appUserService, ISongService songService, JwtTokenHelper jwtTokenHelper, IMapper mapper)
		{
			_appUserService = appUserService;
			_songService = songService;
			_jwtTokenHelper = jwtTokenHelper;
			_mapper = mapper;
		}

		[HttpPost("PlaySong")]
		public async Task<IActionResult> PlaySong([FromBody] PlaySongRequestDto request)
		{
			var songUrl = request.SongUrl?.Replace("~", "").TrimStart('/');
			// ~ karakterini temizle
			var authHeader = Request.Headers["Authorization"].FirstOrDefault();

			if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
				return Unauthorized(new { success = false, message = "Yetkilendirme başlığı eksik." });

			var token = authHeader.Substring("Bearer ".Length).Trim();
			var userPackageId = await _jwtTokenHelper.GetPackageIdFromTokenAsync(token);

			if (userPackageId == null)
				return Unauthorized(new { success = false, message = "Giriş yapmanız gerekiyor." });

			var song = await _songService.TGetSongByUrl(songUrl);
			if (song == null)
				return NotFound(new { success = false, message = "Şarkı bulunamadı." });

			var songDto = _mapper.Map<ResultSongDto>(song);

			if (songDto.CanPlay(userPackageId.Value))
			{
				return Ok(new { success = true, message = "Şarkı çalınıyor!" });
			}

			return BadRequest(new { success = false, message = "Pakete dahil olmayan şarkı." });
		}

	}
}
