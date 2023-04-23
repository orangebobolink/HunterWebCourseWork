using BLL.Mappings;
using BLL.Services.AnimalServices;
using BLL.Services.GenderServices;
using BLL.Services.HuntingSeasonServices;
using BLL.Services.MessangerServices;
using BLL.Services.MethodServices;
using BLL.Services.OrderService;
using BLL.Services.TokeService;
using BLL.Services.TypeServices;
using BLL.Services.UserServices;
using DAL.Configurations;
using DAL.Repositories.HuntingSeasonRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Configurations
{
    public static class DefaultConfiguration
    {
        public static void ConfurationBisnessLogic(this IServiceCollection service, IConfiguration configuration)
        {
            service.ConfurationDataAccess(configuration);
            service.ConfigurationServices();
            service.ConfigurationAutoMapper();
        }

        private static void ConfigurationServices(this IServiceCollection service)
        {
            service.AddScoped<IAnimalService, AnimalService>();
            service.AddScoped<IGenderService, GenderService>();
            service.AddScoped<IHuntingSeasonService, HuntingSeasonService>();
            service.AddScoped<IMessangerService, MessangerService>();
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<ITypeService, TypeService>();
            service.AddScoped<IMethodService, MethodService>();
            service.AddScoped<ITokenService, TokenService>();
            service.AddScoped<IUserService, UserService>();
        }

        private static void ConfigurationAutoMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(
                    typeof(AnimalDetailProfile),
                    typeof(AnimalProfile),
                    typeof(GenderProfile),
                    typeof(HuntingOfSeasonDetailProfile),
                    typeof(HuntingOfSeasonProfile),
                    typeof(MessangerProfile),
                    typeof(MethodOfHuntingProfile),
                    typeof(OrderProfile),
                    typeof(TokenProfile),
                    typeof(TypeOfHuntingProfile)
                );
        }
    }
}
