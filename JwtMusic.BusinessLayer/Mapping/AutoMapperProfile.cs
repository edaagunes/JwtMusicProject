using AutoMapper;
using JwtMusic.DtoLayer.BannerDtos;
using JwtMusic.DtoLayer.ContactDtos;
using JwtMusic.DtoLayer.CountDownDtos;
using JwtMusic.DtoLayer.DjInfoDtos;
using JwtMusic.DtoLayer.EventDtos;
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

		}
	}
}
