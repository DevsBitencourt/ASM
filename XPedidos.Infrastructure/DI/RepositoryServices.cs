using Microsoft.Extensions.DependencyInjection;
using Repository.Clients.Create;
using Repository.Clients.Delete;
using Repository.Clients.Read;
using Repository.Clients.Update;
using Repository.Contract.Clients;
using Repository.Contract.Orders;
using Repository.Contract.OrdersItems;
using Repository.Contract.Products;
using Repository.Orders.Create;
using Repository.Orders.Delete;
using Repository.Orders.Read;
using Repository.Orders.Update;
using Repository.OrdersItems.Create;
using Repository.OrdersItems.Delete;
using Repository.OrdersItems.Update;
using Repository.Products.Create;
using Repository.Products.Delete;
using Repository.Products.Read;
using Repository.Products.Update;

namespace XPedidos.Infrastructure.DI
{
    /// <summary>
    /// Classe dedica a registrar servicos para uso de injeção de dependencia
    /// O serviços registrados aqui são serviços de persistencia ao banco de dados
    /// </summary>
    public class RepositoryServices
    {
        public static void Configure(IServiceCollection services)
        {
            ProdutcsConfigure(services);
            ClientsConfigure(services);
            OrdersConfigure(services);
            OrdersItemsConfigure(services);
        }

        public static void ClientsConfigure(IServiceCollection services)
        {
            services.AddTransient<ICreateClientRepository, CreateClientRepository>();
            services.AddTransient<IReadClientsRepository, ReadClientRepository>();
            services.AddTransient<IUpdateClientRepository, UpdateClientRepository>();
            services.AddTransient<IDeleteClientRepository, DeleteClientRepository>();
        }

        public static void ProdutcsConfigure(IServiceCollection services)
        {
            services.AddTransient<ICreateProductRepository, CreateProductRepository>();
            services.AddTransient<IReadProductRepository, ReadProductRepository>();
            services.AddTransient<IUpdateProductRepository, UpdateProductRepository>();
            services.AddTransient<IDeleteProductRepository, DeleteProductRepository>();
        }

        public static void OrdersConfigure(IServiceCollection services)
        {
            services.AddTransient<ICreateOrderRepository, CreateOrderRepository>();
            services.AddTransient<IReadOrderRepository, ReadOrderRepository>();
            services.AddTransient<IUpdateOrderRepository, UpdateOrderRepository>();
            services.AddTransient<IDeleteOrderRepository, DeleteOrderRepository>();
        }

        public static void OrdersItemsConfigure(IServiceCollection services)
        {
            services.AddTransient<ICreateOrderItemRepository, CreateOrderItemRepository>();
            services.AddTransient<IUpdateOrderItemRepository, UpdateOrderItemRepository>();
            services.AddTransient<IDeleteOrderItemRepository, DeleteOrderItemRepository>();
        }
    }
}
