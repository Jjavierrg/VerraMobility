namespace FraudDetection
{
    using FraudDetection.Entities;
    using FraudDetection.Normalizers;
    using FraudDetection.Readers;
    using FraudDetection.Validators;
    using Microsoft.Extensions.DependencyInjection;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var provider = ContainerManager.Configure();

            var validator = provider.GetService<IValidator<Order>>();
            IOrderReader reader = new SampleOrderReader();

            var orders = await reader.GetOrdersAsync();
            orders.ForEach(order => validator?.Validate(order));

            var frauds = orders.Where(order => order.IsFraud).Select(x => x.OrderId).ToList();
            Console.WriteLine($"Los pagos detectados como fraude son {string.Join(", ", frauds)}");
        }
    }
}