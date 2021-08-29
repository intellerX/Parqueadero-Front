using System;
using System.Linq;
using ADN.Domain.Ports;
using ADN.Domain.Services;
using ADN.Infrastructure.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace ADN.Infrastructure.Extensions
{
    public static class ApiExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            var _services = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName.Contains("Domain", StringComparison.InvariantCulture))
                .SelectMany(s => s.GetTypes())
                .Where(p => p.CustomAttributes.Any(x => x.AttributeType == typeof(DomainServiceAttribute)));

            foreach (var _service in _services)
            {
                services.AddTransient(_service);
            }

            return services;
        }
    }
}