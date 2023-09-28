namespace FraudDetection.Handlers
{
    using FraudDetection.Comparators;
    using FraudDetection.Entities;
    using System.Collections.Generic;

    internal class AddressValidationHandler : AbstractValidatorHandler
    {
        private readonly IEqualityComparer<IAddress> _comparator;

        public AddressValidationHandler(IEqualityComparer<IAddress> comparator) => _comparator = comparator;

        public override IList<Order> GetFraudOrders(IList<Order> orders)
        {
            var existing = base.GetFraudOrders(orders);
            var hashset = new HashSet<Order>();
            var fraudByAdress = orders.Where(i => !hashset.Add(i));

            return fraudByAdress.Concat(existing).ToList();
        }
    }
}
