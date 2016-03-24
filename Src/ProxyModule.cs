using System;
using System.Configuration;
using System.Net.Http;
using Autofac;

namespace NetFlixRoulette
{
    public class ProxyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(55),
                BaseAddress = new Uri(ConfigurationManager.AppSettings["API.URL"])
            };
            
            builder.RegisterInstance(httpClient);
        }
    }
}