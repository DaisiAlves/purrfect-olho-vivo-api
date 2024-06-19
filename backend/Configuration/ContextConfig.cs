﻿using Microsoft.EntityFrameworkCore;
using purrfect_olho_vivo_api.Context;
using purrfect_olho_vivo_api.Services;
using System.Diagnostics.CodeAnalysis;

namespace purrfect_olho_vivo_api.Configuration
{
    public static class ContextConfig
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DBContext")));

            services.AddScoped<ILinhaService, LinhaService>();

            return services;
        }
    }
} 