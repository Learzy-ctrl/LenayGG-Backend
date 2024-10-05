using LGG.LenayGestorGatos.Aplication.Controllers;
using LGG.LenayGestorGatos.Aplication.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace LGG.LenayGestorGatos.Aplication
{
    public static class DContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IApiController, ApiController>();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            //Add new aggregates


            return services;
        }
    }
}
