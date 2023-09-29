namespace FraudDetection.Validators
{
    using FraudDetection.Entities;
    using FraudDetection.Handlers;

    internal class FraudValidator : IValidator<Order>
    {
        IValidatorHandler validatorHandler;
        public FraudValidator(MailValidationHandler mailValidationHandler, AddressValidationHandler addressValidationHandler)
        {
            validatorHandler = mailValidationHandler;
            validatorHandler.SetNext(addressValidationHandler);
        }

        public bool Validate(Order value)
        {
            if (!validatorHandler.IsValid(value))
            {
                var duplicated = validatorHandler.GetDuplicatedOrder(value);
                
                if (duplicated?.DealId != value.DealId)
                    return true;

                if (duplicated == null || string.Equals(duplicated.CreditCard, value.CreditCard, StringComparison.OrdinalIgnoreCase))
                    return true;

                value.IsFraud = duplicated.IsFraud = true;
                return false;
            }

            return true;
        }
    }
}
