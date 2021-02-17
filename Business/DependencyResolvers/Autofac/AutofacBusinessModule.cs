using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module//module bir autofac-startup karşılığı IOC
    {
        protected override void Load(ContainerBuilder builder)//uygulama hayata geçtiği zaman, çalıştırdığımız zaman çalışacak
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();//Iproductservice isterse ona productmanager ver-Startupta Addsingleton ın görevini burası yapıyor
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
