using AutoMapper;
using Restaurante_Proyecto.Data.Entities;
using Restaurante_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante_Proyecto.Data
{
    public class Restaurante_ProyectoProfile : Profile 
    {
        public Restaurante_ProyectoProfile()
        {
            this.CreateMap<RestaurantEntity, Restaurant>().ReverseMap();
            this.CreateMap<DishEntity, Dish>().ReverseMap();
            
            
            //Usar esta notacion cuando las entidades y los modelos sean distintos
            //this.CreateMap<Camp, CampModel>()
            //  .ForMember(c => c.Venue, o => o.MapFrom(m => m.Location.VenueName))
            //  .ReverseMap();

            //this.CreateMap<Talk, TalkModel>()
            //  .ReverseMap()
            //  .ForMember(t => t.Camp, opt => opt.Ignore())
            //  .ForMember(t => t.Speaker, opt => opt.Ignore());

        }
    }
}
