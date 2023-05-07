using DAL.Data;
using DAL.Repositories.AnimalRepository;
using DAL.Repositories.FeedbackRepository;
using DAL.Repositories.HuntingSeasonRepository;
using DAL.Repositories.MessangerRepository;
using DAL.Repositories.OrderRepository;
using DAL.Repositories.RoleRepository;
using DAL.Repositories.StatusRepository;
using DAL.Repositories.TokenRepository;
using DAL.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Configurations
{
    public static class DefaultConfiguration
    {
        public static void ConfurationDataAccess(this IServiceCollection service, IConfiguration configuration)
        {
            service.ConfigurationMSSQLServer(configuration);
            service.ConfigurationRepositories();
        }

        private static void ConfigurationMSSQLServer(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("DAL")));
        }

        private static void ConfigurationRepositories(this IServiceCollection service)
        {
            service.AddScoped<IAnimalRepository, AnimalRepository>();
            service.AddScoped<IRoleRepository, RoleRepository>();
            service.AddScoped<IHuntingSeasonRepository, HuntingSeasonReposiptoty>();
            service.AddScoped<IMessangerRepository, MessangerReposiotry>();
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<ITokenRepository, TokenRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IFeedbackRepository, FeedbackRepository>();
            service.AddScoped<IStatusRepository, StatusRepository>();
        }
    }
}
