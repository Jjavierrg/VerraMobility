namespace FraudDetection.Handlers
{
    using FraudDetection.Entities;

    internal interface IValidatorHandler
    {
        IValidatorHandler SetNext(IValidatorHandler handler);
        bool IsValid(Order order);
        Order? GetDuplicatedOrder(Order order);
    }

}
