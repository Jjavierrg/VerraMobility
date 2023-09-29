namespace FraudDetection.Readers
{
    using FraudDetection.Entities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection.PortableExecutable;
    using System.Text;
    using System.Threading.Tasks;

    internal class SampleOrderReader : IOrderReader
    {
        public async Task<List<Order>> GetOrdersAsync()
        {
            var result = new List<Order>();

            StringBuilder stringToRead = new StringBuilder();
            stringToRead.AppendLine("1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010");
            stringToRead.AppendLine("2,1,elmer@fudd.com,123 Sesame St.,New York,NY,10011,10987654321");
            stringToRead.AppendLine("3,2,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010");

            using (StringReader sr = new StringReader(stringToRead.ToString()))
            {
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    var order = ParseLine(line);
                    if (order != null)
                        result.Add(order);
                }
            }

            return result;
        }

        private Order? ParseLine(string? line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            var orderParts = line.Split(',');
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
