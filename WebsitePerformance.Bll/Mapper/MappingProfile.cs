using AutoMapper;
using WebsitePerformance.Bll.Models;
using WebsitePerformance.Dal.Entities;

namespace WebsitePerformance.Bll.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Webpage, WebpageModel>()
                .ReverseMap();

            CreateMap<Website, WebsiteModel>()
                .ReverseMap();
        }
    }
}
