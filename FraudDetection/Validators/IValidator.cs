namespace FraudDetection.Validators
{
    internal interface IValidator<T>
    {
        bool Validate(T value);
    }
}
