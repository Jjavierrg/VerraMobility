namespace FraudDetection.Readers
{
    using FraudDetection.Entities;
    using FraudDetection.Parsers;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection.PortableExecutable;
    using System.Text;
    using System.Threading.Tasks;

    internal class SampleOrderReader : IOrderReader
    {
        private readonly IOrderParser _parser;

        public SampleOrderReader(IOrderParser parser)
        {
            _parser = parser;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var result = new List<Order>();

            StringBuilder stringToRead = new StringBuilder();
            stringToRead.AppendLine("1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010");
            stringToRead.AppendLine("2,1,elmer@fudd.com,123 Sesame St.,New York,NY,10011,10987654321");
            stringToRead.AppendLine("3,2,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010");

            using (StringReader sr = new(stringToRead.ToString()))
            {
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    var order = _parser.ParseOrder(line);
                    if (order != null)
                        result.Add(order);
                }
            }

            return result;
        }
    }
}
