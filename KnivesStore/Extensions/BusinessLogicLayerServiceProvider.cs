﻿using KnivesStore.BLL.Interfaces;
using KnivesStore.BLL.Models;
using KnivesStore.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KnivesStore.PL.Extensions
{
    public static class BusinessLogicLayerServiceProvider
    {
        public static void AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddScoped<IKnifeService, KnifeService>();
            services.AddScoped<IProducerService, ProducerService>();
            services.AddScoped<IKnifeCategoryService, KnifeCategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IDiscount, FirstDayOfWeekDiscount>();
        }
    }
}
