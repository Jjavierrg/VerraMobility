namespace FraudDetection.Readers
{
    using FraudDetection.Entities;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    internal class FileOrderReader: IOrderReader
    {
        private readonly string _path;

        public FileOrderReader(string path) {
            _path = path;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var result = new List<Order>();
            using (StreamReader sr = File.OpenText(_path))
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

            if (int.TryParse(orderParts[0], out int dealId))
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
