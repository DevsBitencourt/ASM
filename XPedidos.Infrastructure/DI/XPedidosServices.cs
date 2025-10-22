using Business.Clients.Create;
using Business.Clients.Delete;
using Business.Clients.Read;
using Business.Clients.Update;
using Business.Contract.Clients;
using Business.Contract.Clients.Update;
using Business.Contract.Discord;
using Business.Contract.Orders;
using Business.Contract.OrdersItems;
using Business.Contract.Products;
using Business.Discord;
using Business.Orders.Create;
using Business.Orders.Delete;
using Business.Orders.Read;
using Business.Orders.Update;
using Business.OrdersItems;
using Business.Products.Create;
using Business.Products.Delete;
using Business.Products.Read;
using Business.Products.Update;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace XPedidos.Infrastructure.DI
{
    public class XPedidosServices
    {

        public static void Configure(IServiceCollection services)
        {

            ClientsConfigure(services);
            OrdersConfigure(services);
            OrdersItemsConfigure(services);
            ProductsConfigure(services);

            services.AddSingleton<IDiscordServiceBusiness>(provider =>
            {
                try
                {
                    var app = provider.GetService<IConfiguration>();

                    if (app is not null)
                    {
                        if (app.GetSection("DiscordWebHook").Value is not null and string _webHook)
                        {
                            return new DiscordServiceBusiness(_webHook);
                        }
                    }
                    throw new Exception();
                }
                catch (Exception)
                {
                    return new DiscordServiceBusiness(null);
                }
            });
        }

        public static void ClientsConfigure(IServiceCollection services)
        {
            services.AddTransient<ICreateClientBusiness, CreateClientBusiness>();
            services.AddTransient<IReadClientBusiness, ReadClientBusiness>();
            services.AddTransient<IUpdateClientBusiness, UpdateClientBusiness>();
            services.AddTransient<IDeleteClientBusiness, DeleteClientBusiness>();
        }

        public static void OrdersConfigure(IServiceCollection services)
        {
            services.AddTransient<ICreateOrderBusiness, CreateOrderBusiness>();
            services.AddTransient<IReadOrderBusiness, ReadOrderBusiness>();
            services.AddTransient<IUpdateOrderBusiness, UpdateOrderBusiness>();
            services.AddTransient<IDeleteOrderBusiness, DeleteOrderBusiness>();
        }

        public static void ProductsConfigure(IServiceCollection services)
        {
            services.AddTransient<ICreateProductBusiness, CreateProductBusiness>();
            services.AddTransient<IReadProductBusiness, ReadProductBusiness>();
            services.AddTransient<IUpdateProductBusiness, UpdateProductBusiness>();
            services.AddTransient<IDeleteProductBusiness, DeleteProductBusiness>();
        }

        public static void OrdersItemsConfigure(IServiceCollection services)
        {
            services.AddTransient<ICreateOrderItemBusiness, CreateOrderItemBusiness>();
            services.AddTransient<IUpdateOrderItemBusiness, UpdateOrderItemBusiness>();
            services.AddTransient<IDeleteOrderItemBusiness, DeleteOrderItemBusiness>();
        }
    }
}
