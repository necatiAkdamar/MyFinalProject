using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();//memorycache i injection yapabilmek için ekledik
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//servis bağımlılıklarımızı çözümleyeceğimiz yer
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();//birisi ICacheManager isterse ona MemoryCacheManager ver
        }
    }
}
