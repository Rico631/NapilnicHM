using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Second;
using Second.Context;
using Second.Interfaces;
using Second.Models;
using System;

namespace SecondConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = GetServiceProvider();

            var customerService = provider.GetRequiredService<ICustomerService>();
            var warehouseService = provider.GetRequiredService<IWarehouseService>();
            var orderService = provider.GetRequiredService<IOrderService>();
            var productService = provider.GetRequiredService<IProductService>();

            var currentCustomer = customerService.CreateCurrentCustomer();

            var iPhone11 = productService.CreateProduct(new Product("iphone11", 123));
            var iPhone12 = productService.CreateProduct(new Product("iphone12", 312));

            warehouseService.CreateStock(new Stock(iPhone11, 10));
            warehouseService.CreateStock(new Stock(iPhone12, 1));

            var orderBuilder = new OrderBuilder(currentCustomer, warehouseService, orderService);


            orderBuilder.AddProduct(iPhone11, 4);
            try
            {
                orderBuilder.AddProduct(iPhone12, 3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Не удалось добавить в корзину продукт: {0}. Ошибка:{1}", iPhone12.Name, ex.Message);
            }

            Console.WriteLine(orderBuilder.PayLink);

            Console.ReadKey();
        }

        private static IServiceProvider GetServiceProvider()
        {
            //setup dependency injection
            IServiceCollection services = new ServiceCollection();
            services.AddSecond();
            services.AddDbContext<ShopContext>((options) => options.UseInMemoryDatabase(databaseName: "test"));

            return services.BuildServiceProvider();
        }
    }
}
