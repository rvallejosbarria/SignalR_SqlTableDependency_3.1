using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SignalR_SqlTableDependency_3._1.SubscribeTableDependencies;

namespace SignalR_SqlTableDependency_3._1.MiddlewareExtensions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseProductTableDependency(this IApplicationBuilder applicationBuilder)
        {
            var serviceProvider = applicationBuilder.ApplicationServices;
            var service = serviceProvider.GetService<SubscribeProductTableDependency>();
            service.SubscribeTableDependency();
        }
    }
}
