namespace FraudDetection.Readers
{
    using FraudDetection.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal interface IOrderReader
    {
        Task<List<Order>> GetOrdersAsync();
    }
}
