using AutoMapper;
using Onion.Core.UnitOfWork;
using Onion.Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Onion.Infra.DbContexts;
using Onion.App.Mapping;
using Onion.Core.Repositories.BaseRepositories;
using Onion.Infra.Repositories.BaseRepository;
using Onion.Core.Repositories.CustomRepositories;
using Onion.Infra.Repositories.CustomRepository;
using Onion.Core.Services.BaseServices;
using Onion.App.Services.BaseServices;
using Onion.Core.Services.CustomerServices;
using Onion.App.Services.CustomerServices;
using Onion.Core.Commands.Customers;
using Onion.App.CommandHandelers;
using Onion.App.Queries.Customers;
using Onion.Core.Models.ViewModels;
using Onion.App.QueryHandelers;
using Onion.Core.Models.Infrastructure;
using System.Reflection;

namespace Onion.Host.Infrastructure
{
    public static class ServiceCollectionExtention
    {

        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomerProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }

        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped(typeof(IBaseReadRepository<>), typeof(BaseReadRepository<>));
            serviceCollection.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            serviceCollection.AddScoped(typeof(ICustomerReadonlyRepository), typeof(CustomerReadonlyRepository));
        }

        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            serviceCollection.AddScoped(typeof(ICustomerService), typeof(CustomerService));
        }

        public static void AddHandellers(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddScoped<IRequestHandler<CreateCustomerCommand, Guid>, CreateCustomerCommandHandeler>();
            //serviceCollection.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, UpdateCustomerCommandHandeler>();
            //serviceCollection.AddScoped<IRequestHandler<DeleteCustomerCommand, bool>, DeleteCustomerCommandHandeler>();
            //serviceCollection.AddScoped<IRequestHandler<ActivateCustomerCommand, bool>, ActivateCustomerCommandHandeler>();
            //serviceCollection.AddScoped<IRequestHandler<SuspendCustomerCommand, bool>, SuspendCustomerCommandHandeler>();
            //serviceCollection.AddScoped<IRequestHandler<GetCustomerByIdCommand, CustomerVm>, GetCustomerByIdCommandHandeler>();
            //serviceCollection.AddScoped<IRequestHandler<GetCustomerBySearchCommand, PagedListModel<CustomerVm>>, GetCustomerBySearchCommandHandeler>();

        }

        public static void AddDbContexts(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<AppDbContext>(
                opt  => opt.UseSqlServer (configuration.GetConnectionString("DefaultConnection")));

            serviceCollection.AddDbContext<ReedingDbContext>(
               opt => opt.UseSqlServer(configuration.GetConnectionString("ReplicaConnection")));
        }

        public static void AddUnitOfWork(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddMediatR(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddMediatR(AppDomain.CurrentDomain.GetAssemblies().Single(x => x.FullName.Contains("Onion.App")));

            
            //serviceCollection.AddMediatR();

            //serviceCollection.AddMediatR(typeof(Program).Assembly);
        }



    }
}
