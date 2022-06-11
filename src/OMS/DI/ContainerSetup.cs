using OMS.Data.Access.DAL;
using System.Reflection;
using System.Runtime.CompilerServices;
using OMS.Queries.QueryProcessors;
using OMS.Maps;

namespace OMS.DI
{
    public static class ContainerSetup
    {
        public static void Setup(IServiceCollection services)
        {
            AddUow(services);
            AddQueries(services);
            ConfigureAutoMapper(services);
        }
        private static void AddUow(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork>(ctx => new EFUnitOfWork(ctx.GetRequiredService<OMSDbContext>()));
        }

        private static void ConfigureAutoMapper(IServiceCollection services)
        {
            var mapperConfig = AutoMapperConfigurator.Configure();
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(x => mapper);
            services.AddTransient<IAutoMapper, AutoMapperAdapter>();
        }


        private static void AddQueries(IServiceCollection services)
        {
            var exampleProcessorType = typeof(CategoryQueryProcessor);
            var types = (from t in exampleProcessorType.GetTypeInfo().Assembly.GetTypes()
                         where t.Namespace == exampleProcessorType.Namespace
                               && t.GetTypeInfo().IsClass
                               && t.GetTypeInfo().GetCustomAttribute<CompilerGeneratedAttribute>() == null
                         select t).ToArray();

            foreach (var type in types)
            {
                var interfaceQ = type.GetTypeInfo().GetInterfaces().First();
                services.AddScoped(interfaceQ, type);
            }
        }
    }
}