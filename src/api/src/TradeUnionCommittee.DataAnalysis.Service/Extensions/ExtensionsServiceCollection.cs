﻿using Microsoft.Extensions.DependencyInjection;
using TradeUnionCommittee.DataAnalysis.Service.Interfaces;
using TradeUnionCommittee.DataAnalysis.Service.Services;

namespace TradeUnionCommittee.DataAnalysis.Service.Extensions
{
    public static class ExtensionsServiceCollection
    {
        public static IServiceCollection AddDataAnalysisService(this IServiceCollection services, string url)
        {
            services.AddSingleton(x => new DataAnalysisClient(url));
            services.AddTransient<ITestService, TestService>();
            return services;
        }
    }
}