using AutoMapper;
using JwtMusic.DtoLayer.AppUserDtos;
using JwtMusic.DtoLayer.BannerDtos;
using JwtMusic.DtoLayer.ContactDtos;
using JwtMusic.DtoLayer.CountDownDtos;
using JwtMusic.DtoLayer.DjInfoDtos;
using JwtMusic.DtoLayer.EventDtos;
using JwtMusic.DtoLayer.PackageDtos;
using JwtMusic.DtoLayer.SongDtos;
using JwtMusic.EntityLayer.Entities;


namespace JwtMusic.BusinessLayer.Mapping
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Banner, ResultBannerDto>().ReverseMap();
			CreateMap<Banner, CreateBannerDto>().ReverseMap();
			CreateMap<Banner, UpdateBannerDto>().ReverseMap();

			CreateMap<Contact, ResultContactDto>().ReverseMap();
			CreateMap<Contact, CreateContactDto>().ReverseMap();
			CreateMap<Contact, UpdateContactDto>().ReverseMap();
			
			CreateMap<CountDown, ResultCountDownDto>().ReverseMap();
			CreateMap<CountDown, CreateCountDownDto>().ReverseMap();
			CreateMap<CountDown, UpdateCountDownDto>().ReverseMap();

			CreateMap<DjInfo, ResultDjInfoDto>().ReverseMap();
			CreateMap<DjInfo, CreateDjInfoDto>().ReverseMap();
			CreateMap<DjInfo, UpdateDjInfoDto>().ReverseMap();

			CreateMap<Event, ResultEventDto>().ReverseMap();
			CreateMap<Event, CreateEventDto>().ReverseMap();
			CreateMap<Event, UpdateEventDto>().ReverseMap();

			CreateMap<Song, ResultSongDto>()
			.ForMember(dest => dest.PackageIds, opt => opt.MapFrom(src => src.Packages.Select(p => p.PackageId).ToList())).ReverseMap();

			CreateMap<Song, CreateSongDto>().ReverseMap();
			CreateMap<Song, UpdateSongDto>().ReverseMap();

			CreateMap<Package, ResultPackageDto>().ReverseMap();
			CreateMap<Package, CreatePackageDto>().ReverseMap();
			CreateMap<Package, UpdatePackageDto>().ReverseMap();

			CreateMap<AppUser, ResultAppUserDto>().ReverseMap();
			CreateMap<AppUser, UpdateAppUserDto>().ReverseMap();
		}
	}
}
