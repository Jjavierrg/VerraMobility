namespace FraudDetection.Handlers
{
    using FraudDetection.Entities;
    using System.Collections.Generic;

    internal class AddressValidationHandler : HashSetValidatorHandler
    {
        public AddressValidationHandler(IEqualityComparer<IAddress> comparer) : base(comparer) { }
    }
}
