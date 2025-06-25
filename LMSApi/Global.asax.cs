using AutoMapper;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace LMSApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static IMapper MapperInstance { get; private set; }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            MapperInstance = config.CreateMapper();
        }
    }
}
