namespace FraudDetection.Readers
{
    using FraudDetection.Entities;
    using FraudDetection.Parsers;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    internal class FileOrderReader: IOrderReader
    {
        private readonly string _path;
        private readonly IOrderParser _parser;

        public FileOrderReader(string path, IOrderParser parser) {
            _path = path;
            _parser = parser;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var result = new List<Order>();
            using (StreamReader sr = File.OpenText(_path))
            {
                await sr.ReadLineAsync(); // total not used on this approach

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
