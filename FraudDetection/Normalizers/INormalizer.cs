namespace FraudDetection.Normalizers
{
    internal interface INormalizer<in T>
    {
        string Normalize(T? input);
    }
}
