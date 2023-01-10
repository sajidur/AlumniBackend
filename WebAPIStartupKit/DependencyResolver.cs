using StarterKITDAL;
using StarterKITDAL.Repository;
using StartKitBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace WebAPIStartupKit
{
    public class DependencyResolver
    {
        public static void Resolve(HttpConfiguration config)
        {
            var container = new UnityContainer();          

            config.DependencyResolver = new UnityResolver(container);
        }

    }
}