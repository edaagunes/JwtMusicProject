using AutoMapper;
using JwtMusic.DtoLayer.BannerDtos;
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
		}
	}
}
