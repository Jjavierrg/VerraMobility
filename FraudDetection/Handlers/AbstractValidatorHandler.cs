namespace FraudDetection.Handlers
{
    using FraudDetection.Entities;

    internal abstract class AbstractValidatorHandler : IValidatorHandler
    {
        private IValidatorHandler _nextHandler;        

        public IValidatorHandler SetNext(IValidatorHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual IList<Order> GetFraudOrders(IList<Order> orders)
        {
            return _nextHandler?.GetFraudOrders(orders) ?? Enumerable.Empty<Order>().ToList();
        }
    }

}
