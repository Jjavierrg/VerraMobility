namespace FraudDetection.Handlers
{
    using FraudDetection.Comparators;
    using FraudDetection.Entities;
    using System.Collections.Generic;

    internal class MailValidationHandler : AbstractValidatorHandler
    {
        private readonly IEqualityComparer<IEmail> _comparator;

        public MailValidationHandler(IEqualityComparer<IEmail> comparator) => _comparator = comparator;

        public override IList<Order> GetFraudOrders(IList<Order> orders)
        {
            var existing = base.GetFraudOrders(orders);
            var hashset = new HashSet<Order>();
            var fraudByAdress = orders.Where(i => !hashset.Add(i));

            return fraudByAdress.Concat(existing).ToList();
        }
    }
}
