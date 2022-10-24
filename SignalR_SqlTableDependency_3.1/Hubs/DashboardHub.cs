using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SignalR_SqlTableDependency_3._1.Repositories;

namespace SignalR_SqlTableDependency_3._1.Hubs
{
    public class DashboardHub : Hub
    {
        private readonly ProductRepository _productRepository;

        public DashboardHub(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _productRepository = new ProductRepository(connectionString);
        }

        public async Task SendProducts()
        {
            var products = _productRepository.GetProducts();
            await Clients.All.SendAsync("ReceivedProducts", products);
        }
    }
}
