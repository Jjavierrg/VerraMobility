namespace FraudDetection.Validators
{
    using FraudDetection.Comparators;
    using FraudDetection.Entities;
    using FraudDetection.Handlers;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class FraudValidator : IValidator<Order>
    {
        IValidatorHandler validatorHandler;
        public FraudValidator()
        {
            var mailComparer = new MailComparer();
            validatorHandler = new MailValidationHandler(mailComparer);

            var addresComparer = new AddressComparer();
            validatorHandler.SetNext(new AddressValidationHandler(addresComparer));
        }
        public IEnumerable<Order> GetNotValidValues(IList<Order> values)
        {
            if (values == null)
                return Enumerable.Empty<Order>();

            var valid

            var fraudIndex = new List<int>();
            for (int i = 0; i < values.Count(); i++)
            {
                if (values.Contains()
            }
        }
    }
}
