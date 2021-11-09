using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Core.Models;
using TShirtShop.Core.ViewModels;

namespace TShirtShop.Data
{
    public class TShirtProfile : Profile
    {
        public TShirtProfile()
        {
            this.CreateMap<Shirt, ShirtViewModel>()
                .ForMember(s => s.Sizes, opt => opt.Ignore())
                .ForMember(s => s.Genders, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(s => s.Size, opt => opt.Ignore());
                
                
               
        }
    }
}
