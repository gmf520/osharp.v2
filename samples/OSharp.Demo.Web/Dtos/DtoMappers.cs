using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

using OSharp.Demo.Web.Models;


namespace OSharp.Demo.Web.Dtos
{
    public class DtoMappers
    {
        public static void MapperRegister()
        {
            //Identity
            Mapper.CreateMap<OrganizationDto, Organization>();
            Mapper.CreateMap<UserDto, User>();
            Mapper.CreateMap<RoleDto, Role>();
        }
    }
}