namespace FraudDetection.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    internal interface IAddress
    {
        Address Address { get; set; }
    }

    internal interface IEmail
    {
        string Email { get; set; }
    }

    internal interface ICreditCard
    {
        string CreditCard { get; set; }
    }

    internal class Order: IAddress, IEmail, ICreditCard
    {
        public int OrderId { get; set; }
        public int DealId { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string CreditCard { get; set; }
    }
}
