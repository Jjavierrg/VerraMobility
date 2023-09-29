namespace FraudDetection.Normalizers
{
    using FraudDetection.Comparators;
    using FraudDetection.Entities;
    using FraudDetection.Handlers;
    using FraudDetection.Validators;
    using Microsoft.Extensions.DependencyInjection;

    public class ContainerManager
    {
        public static ServiceProvider Configure()
        {
            var services = new ServiceCollection();

            services.AddTransient<INormalizer<IAddress>, AddressNormalizer>();
            services.AddTransient<INormalizer<IEmail>, EmailNormalizer>();

            services.AddTransient(typeof(IEqualityComparer<>), typeof(BaseComparer<>));
            
            services.AddScoped<MailValidationHandler>();
            services.AddScoped<AddressValidationHandler>();

            services.AddScoped<IValidator<Order>, FraudValidator>();

            return services.BuildServiceProvider();
        }
    }
}
