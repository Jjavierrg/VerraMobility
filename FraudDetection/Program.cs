namespace FraudDetection
{
    using FraudDetection.Entities;
    using FraudDetection.Normalizers;
    using FraudDetection.Parsers;
    using FraudDetection.Readers;
    using FraudDetection.Validators;
    using Microsoft.Extensions.DependencyInjection;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var provider = ContainerManager.Configure();

            var validator = provider.GetService<IValidator<Order>>();
            var parser = provider.GetRequiredService<IOrderParser>();
            IOrderReader reader = new FileOrderReader("data.txt", parser);
            // IOrderReader reader = new SampleOrderReader(parser);

            var orders = await reader.GetOrdersAsync();
            orders.ForEach(order => validator?.Validate(order));

            var frauds = orders.Where(order => order.IsFraud).Select(x => x.OrderId).ToList();
            Console.WriteLine($"Los pagos detectados como fraude son {string.Join(", ", frauds)}");
        }
    }
}