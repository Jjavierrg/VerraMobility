namespace FraudDetection.Handlers
{
    using FraudDetection.Entities;
    using System.Collections.Generic;

    internal class MailValidationHandler : HashSetValidatorHandler
    {
        public MailValidationHandler(IEqualityComparer<IEmail> comparer) : base(comparer) { }
    }
}
