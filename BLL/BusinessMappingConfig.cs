﻿using AutoMapper;
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

            config.CreateMap<UnitGroup, UnitGroupSpecificationUnitsDTO>().ReverseMap();

            config.CreateMap<UnitType, UnitTypeDTO>().ReverseMap();

            config.CreateMap<User, UserNameDTO>().ReverseMap();
            config.CreateMap<User, UserNameEmailAdminDTO>().ReverseMap();
            config.CreateMap<User, UserNameEmailDTO>().ReverseMap();
        }
    }
}