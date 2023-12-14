using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Concretes;
using Business.Rules;
using Core.Business.Rules;

namespace Business
{

    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICustomerService, CustomerManager>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));
            return services;
        }
        public static IServiceCollection AddSubClassesOfType(
            this IServiceCollection services,
            Assembly assembly,
            Type type,
            Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
        )
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                if (addWithLifeCycle == null)
                    services.AddScoped(item);

                else
                    addWithLifeCycle(services, type);
            return services;
        }
    }

}
