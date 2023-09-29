namespace FraudDetection.Handlers
{
    using FraudDetection.Entities;

    internal abstract class HashSetValidatorHandler : IValidatorHandler
    {
        private IValidatorHandler? _nextHandler;
        private readonly HashSet<Order> ordersHashSet;

        protected HashSetValidatorHandler(IEqualityComparer<Order> comparer)
        {
            ordersHashSet = new HashSet<Order>(comparer);
        }

        public IValidatorHandler SetNext(IValidatorHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public bool IsValid(Order order)
        {
            ordersHashSet.Add(order);

            if (_nextHandler != null && !_nextHandler.IsValid(order))
                return false;

            if (GetDuplicatedOrder(order) != null)
                return false;

            return true;
        }

        public Order? GetDuplicatedOrder(Order order)
        {
            if (ordersHashSet.TryGetValue(order, out Order? existingOrder) && existingOrder != order)
                return existingOrder;

            return _nextHandler?.GetDuplicatedOrder(order);
        }
    }

}
