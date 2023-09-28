namespace FraudDetection.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal interface IValidator<T>
    {
        IEnumerable<T> GetNotValidValues(IEnumerable<T> values);
    }
}
