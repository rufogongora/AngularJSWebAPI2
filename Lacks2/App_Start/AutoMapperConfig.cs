using Lacks2.Models;
using Lacks2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lacks2.App_Start {
    public class AutoMapperConfig {
        public static void RegisterMappings() {
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Person, PersonViewModel>().ReverseMap();
                cfg.CreateMap<Food, FoodViewModel>().ReverseMap();
            });
        }
    }
}