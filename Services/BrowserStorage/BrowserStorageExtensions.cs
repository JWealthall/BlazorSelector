using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSelector.Services
{
    public static class BrowserStorageExtensions
    {
        public static IServiceCollection AddBrowserStorage(this IServiceCollection services)
        {
            return services // Note: If we require it we can inject specific MessagePack and/or Json Serializers
                    .AddSingleton<ILocalStorageProvider, LocalStorageProvider>()
                    .AddSingleton<ISessionStorageProvider, SessionStorageProvider>()
                    .AddSingleton<ILocalStorageService, LocalStorageService>()
                    .AddSingleton<ISessionStorageService, SessionStorageService>()
                ; 
        }
    }}
