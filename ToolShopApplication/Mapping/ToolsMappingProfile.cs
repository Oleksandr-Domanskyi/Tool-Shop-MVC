using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopApplication.CQRS.Command.CreateEntity;
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
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Request.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Request.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Request.Price))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Request.Description))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Request.Category))
                .ForMember(dest => dest.image, opt => opt.MapFrom(src => ImageHandler.ImageToByteParse(src.Request.Image)));

            CreateMap<ToolProfileRequest,ToolProfile>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.image, opt => opt.Ignore()).ReverseMap();
        }
    }
}
