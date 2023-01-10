using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using StarterKITDAL;
using StartKitBLL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIStartupKit
{
    public class UserProfile:Profile
    {
        public static IMapper Mapper { get; set; }
        public static void RegisterProfiles()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //Create all maps here
                //...
            });
            config.AssertConfigurationIsValid();
            Mapper = config.CreateMapper();
        }
   
    }
}