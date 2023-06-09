﻿using BLL.Mappings;
using BLL.Services.AnimalServices;
using BLL.Services.AuthServices;
using BLL.Services.FeedbackServices;
using BLL.Services.HuntingSeasonServices;
using BLL.Services.MessangerServices;
using BLL.Services.OrderService;
using BLL.Services.RoleServices;
using BLL.Services.StatusServices;
using BLL.Services.TokeService;
using BLL.Services.UserServices;
using DAL.Configurations;
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
            service.AddScoped<IHuntingSeasonService, HuntingSeasonService>();
            service.AddScoped<IAnimalService, AnimalService>();
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IMessangerService, MessangerService>();
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<ITokenService, TokenService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IFeedbackService, FeedbackService>();
            service.AddScoped<IStatusService, StatusService>();
            service.AddScoped<IRoleService, RoleService>();
        }

        private static void ConfigurationAutoMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(
                    typeof(AnimalProfile),
                    typeof(HuntingOfSeasonProfile),
                    typeof(MessangerProfile),
                    typeof(OrderProfile),
                    typeof(TokenProfile),
                    typeof(FeedbackProfile)
                );
        }
    }
}
