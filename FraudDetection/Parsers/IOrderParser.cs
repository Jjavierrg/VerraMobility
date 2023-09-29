namespace FraudDetection.Parsers
{
    using FraudDetection.Entities;

    internal interface IOrderParser
    {
        Order? ParseOrder(string input);
    }
}
