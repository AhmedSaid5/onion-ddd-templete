using AutoMapper;
using Onion.Core.UnitOfWork;
using Onion.Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Onion.Infra.DbContexts;

namespace Onion.Host.Infrastructure
{
    public static class ServiceCollectionExtention
    {


        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                //mc.AddProfile(new CustomerMapper());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }

        public static void AddRepositories(this IServiceCollection serviceCollection)
        {

        }

        public static void AddHandellers(this IServiceCollection serviceCollection)
        {

        }

        public static void AddDbContexts(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<AppDbContext>(
                opt  => opt.UseSqlServer (configuration.GetConnectionString("DefaultConnection")));

            serviceCollection.AddDbContext<ReedingDbContext>(
               opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }


        public static void AddUnitOfWork(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void AddMediatR(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(Program));
        }



    }
}
