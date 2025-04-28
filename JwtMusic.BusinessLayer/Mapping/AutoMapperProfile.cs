using AutoMapper;
using JwtMusic.DtoLayer.BannerDtos;
using JwtMusic.DtoLayer.ContactDtos;
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
		}
	}
}
