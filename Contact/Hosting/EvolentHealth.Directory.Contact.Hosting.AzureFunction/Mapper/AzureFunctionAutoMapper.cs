
using AutoMapper;
using EvolentHealth.Directory.Contact.Contract.Models.Dto;

namespace EvolentHealth.Directory.Contact.Hosting.AzureFunction.Mapper
{
    public static class AzureFunctionAutoMapper
    {
        public static readonly IMapper Mapper;

        static AzureFunctionAutoMapper()
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
