using AutoMapper;
using CoreApp.Common;
using CoreApp.Domain.Entities;
using CoreApp.Services.Dtos;
using CoreApp.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public static class DtoMappings
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                // ENTITY TO DTO
                #region ENTITY TO DTO
                cfg.CreateMap<User, IdentityUser>()
                    .ForMember(dest => dest.Id,
                        opts => opts.MapFrom(src => src.UserId));
                ;
                cfg.CreateMap<Language, LanguageDto>();
                cfg.CreateMap<User, UserDto>().ForMember(des=>des.Role ,opt=>opt.MapFrom(src=>src.Roles.ToList().Any()? src.Roles.ToList()[0].Name:""));
                #endregion

                // DTO TO ENTITY
                #region DTO TO ENTTY
                cfg.CreateMap<IdentityUser, User>()
                    .ForMember(dest => dest.UserId,
                        opts => opts.MapFrom(src => src.Id));
                ;
                cfg.CreateMap<LanguageDto, Language>();
                #endregion
            });

        }
    }
}
