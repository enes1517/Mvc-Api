﻿using Microsoft.EntityFrameworkCore;
using Presentation.ActionFilters;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();    
        }
        public static void ConfigureServiceManager(this IServiceCollection services)
        {
           
            services.AddScoped<IServiceManager,ServiceManager>();
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService,LoggerManager>();
        }
        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();  //IoC
            services.AddSingleton<LogFilterAttribute>();

        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options=>options.AddPolicy("CorsPolicy",builder=>
            builder.AllowAnyOrigin().
            AllowAnyHeader().
            AllowAnyMethod().
            WithExposedHeaders("X-Pagination")));
        }
    }
}
