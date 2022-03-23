using AutoMapper;
using Web_Exercise___Consid.Models.Dtos;
using Web_Exercise___Consid.Models.Entities;

namespace Web_Exercise___Consid.Profiles
{
    public class DtoReader : Profile
    {
        public DtoReader()
        {
            CreateMap<Company,CompanyDto>();
            CreateMap<Store,StoreDto>();

        }
    }
}
