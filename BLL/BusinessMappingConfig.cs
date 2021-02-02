using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL
{
    public class BusinessMappingConfig
    {
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<Address, AddressCityLocalDTO>().ReverseMap();
            config.CreateMap<Address, AddressFullDTO>().ReverseMap();

            config.CreateMap<Equipment, EquipmentTypeDTO>().ReverseMap();
            config.CreateMap<Equipment, EquipmentUnitAvailableEquipmentDTO>().ReverseMap();

            config.CreateMap<Specification, SpecificationFullDetailDTO>().ReverseMap();
            config.CreateMap<Specification, SpecificationNameColorDTO>().ReverseMap();
            config.CreateMap<Specification, SpecificationNameColorNoteDTO>().ReverseMap();
            config.CreateMap<Specification, SpecificationNameNoteAddressDTO>().ReverseMap();

            config.CreateMap<Unit, UnitFullDTO>().ReverseMap();
            config.CreateMap<Unit, UnitShowDTO>().ReverseMap();
            config.CreateMap<Unit, UnitTypeDTO>().ReverseMap();
            config.CreateMap<Unit, UnitDTO>().ReverseMap();

            config.CreateMap<UnitGroup, UnitGroupSpecificationUnitsDTO>().ReverseMap();
            config.CreateMap<UnitGroup, UnitGroupDTO>().ReverseMap();
            config.CreateMap<UnitGroup, UnitGroupNameDto>().ReverseMap();

            config.CreateMap<UnitType, UnitTypeDTO>().ReverseMap();

            config.CreateMap<Color, ColorDTO>().ReverseMap();

            config.CreateMap<User, UserNameDTO>().ReverseMap();
            config.CreateMap<User, UserIdNameEmailAdminDTO>().ReverseMap();
            config.CreateMap<User, UserNameEmailDTO>().ReverseMap();
            config.CreateMap<User, UserCreateDTO>().ReverseMap();
            config.CreateMap<User, UserNamePasswordEmailAdminDTO>().ReverseMap();
            config.CreateMap<User, UserShowDTO>().ReverseMap();

        }
    }
}