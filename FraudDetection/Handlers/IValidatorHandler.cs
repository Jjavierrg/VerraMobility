namespace FraudDetection.Handlers
{
    using FraudDetection.Entities;

    internal interface IValidatorHandler
    {
        IValidatorHandler SetNext(IValidatorHandler handler);
        IList<Order> GetFraudOrders(IList<Order> orders);
    }

}
