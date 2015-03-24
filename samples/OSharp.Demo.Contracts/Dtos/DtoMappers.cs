// -----------------------------------------------------------------------
//  <copyright file="DtoMappers.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2015 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2015-03-24 16:13</last-date>
// -----------------------------------------------------------------------

using AutoMapper;

using OSharp.Demo.Dtos.Identity;
using OSharp.Demo.Models.Identity;


namespace OSharp.Demo.Dtos
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