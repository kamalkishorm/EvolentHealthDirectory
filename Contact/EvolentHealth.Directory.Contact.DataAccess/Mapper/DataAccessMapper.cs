using AutoMapper;
using EvolentHealth.Directory.Contact.Contract.Models.Dto;

namespace EvolentHealth.Directory.Contact.DataAccess.Mapper
{
    public static class DataAccessAutoMapper
    {
        public static readonly IMapper Mapper;

        static DataAccessAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contract.Models.Business.Contact, ContactDto>();
                cfg.CreateMap<ContactDto, Contract.Models.Business.Contact>();
            });
            config.AssertConfigurationIsValid();
            Mapper = config.CreateMapper();
        }
    }
}
