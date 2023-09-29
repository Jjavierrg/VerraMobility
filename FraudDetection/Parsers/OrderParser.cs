namespace FraudDetection.Parsers
{
    using FraudDetection.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class OrderParser: IOrderParser
    {
        public Order? ParseOrder(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            var orderParts = input.Split(',');
            if (orderParts.Length < 8) return null;

            var order = new Order { Address = new Address(), IsFraud = false };

            if (int.TryParse(orderParts[0], out int orderId))
                order.OrderId = orderId;

            if (int.TryParse(orderParts[1], out int dealId))
                order.DealId = dealId;

            order.Email = orderParts[2];
            order.Address.Street = orderParts[3];
            order.Address.City = orderParts[4];
            order.Address.State = orderParts[5];
            order.Address.ZipCode = orderParts[6];
            order.CreditCard = orderParts[7];

            return order;
        }
    }
}
