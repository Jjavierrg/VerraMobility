namespace FraudDetection.Comparators
{
    using FraudDetection.Normalizers;
    using System;
    using System.Diagnostics.CodeAnalysis;

    internal class BaseComparer<T> : IEqualityComparer<T>
    {
        private readonly INormalizer<T> _normalizer;

        public BaseComparer(INormalizer<T> normalizer) => _normalizer = normalizer;

        public bool Equals(T? x, T? y)
        {
            var normalizedX = _normalizer.Normalize(x);
            var normalizedY = _normalizer.Normalize(y);

            return string.Equals(normalizedY, normalizedX, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode([DisallowNull] T obj) => _normalizer.Normalize(obj).GetHashCode();
    }
}
