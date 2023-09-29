namespace FraudDetection.Normalizers
{
    using FraudDetection.Entities;
    using System;
    using System.Text;

    internal class AddressNormalizer : INormalizer<IAddress>
    {
        private const string EMPTY_PLACEHOLDER = "<empty>";
        private const string SEPARATOR = "||";
        public string Normalize(IAddress? input)
        {
            if (input == null)
                return string.Empty;

            var builder = new StringBuilder();

            var normalizedStreet = NormalizeStreet(input.Address.Street);
            var normalizedState = NormalizeState(input.Address.State);
            var normalizedCity = NormalizeInput(input.Address.City);
            var normalizedZipCode = NormalizeInput(input.Address.ZipCode);

            builder.AppendJoin(SEPARATOR, new string[] { normalizedStreet, normalizedState, normalizedCity, normalizedZipCode });
            return builder.ToString();
        }

        private string NormalizeStreet(string street)
        {
            return NormalizeInput(street)
                .Replace(" st.", " Street", StringComparison.OrdinalIgnoreCase)
                .Replace(" rd.", " Road", StringComparison.OrdinalIgnoreCase);
        }


        private string NormalizeState(string state)
        {
            return NormalizeInput(state)
                .Replace("il", "Illinois", StringComparison.OrdinalIgnoreCase)
                .Replace("ca", "California", StringComparison.OrdinalIgnoreCase)
                .Replace("ny", "New York", StringComparison.OrdinalIgnoreCase);
        }

        private string NormalizeInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return EMPTY_PLACEHOLDER;

            return input.ToLower().Trim();
        }
    }
}
