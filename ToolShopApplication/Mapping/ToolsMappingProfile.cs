using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopApplication.CQRS.Command.CreateEntity;
using ToolShopApplication.CQRS.Command.UpdateEntity;
using ToolShopApplication.CQRS.Queries.GetEntity;
using ToolShopApplication.DataTransferObject;
using ToolShopApplication.Helpers;
using ToolShopDomainCore.Domain.Entity;

namespace ToolShopApplication.Mapping
{
    public class ToolsMappingProfile:Profile
    {
        public ToolsMappingProfile()
        {
            CreateMap<ToolProfile,ToolProfileDto>();

            CreateMap<CreateEntityCommand<ToolProfile,ToolProfileRequest>, ToolProfile>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src._request.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src._request.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src._request.Price))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src._request.Description))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src._request.Category))
                .ForMember(dest => dest.image, opt => opt.MapFrom(src => ImageHandler.ImageToByteParse(src._request.Image)));

            CreateMap<UpdateEntityCommand<ToolProfile, ToolProfileRequest>, ToolProfile>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src._request.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src._request.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src._request.Price))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src._request.Description))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src._request.Category))
                .ForMember(dest => dest.image, opt => opt.MapFrom(src => ImageHandler.ImageToByteParse(src._request.Image)));
        }
    }
}
