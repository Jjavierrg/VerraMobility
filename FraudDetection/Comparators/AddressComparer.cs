namespace FraudDetection.Comparators
{
    using FraudDetection.Entities;
    using System;
    using System.Diagnostics.CodeAnalysis;

    internal class AddressComparer : IEqualityComparer<IAddress>
    {
        private string NormalizeStreet(string street)
        {
            return street
                .Replace(" st.", " Street", StringComparison.OrdinalIgnoreCase)
                .Replace(" rd.", " Road", StringComparison.OrdinalIgnoreCase);
        }


        private string NormalizeState(string state)
        {
            return state
                .Replace("il", "Illinois", StringComparison.OrdinalIgnoreCase)
                .Replace("ca", "California", StringComparison.OrdinalIgnoreCase)
                .Replace("ny", "New York", StringComparison.OrdinalIgnoreCase);
        }

        public bool Equals(IAddress? one, IAddress? other)
        {
            if (one == null || other == null)
                return false;

            if (!string.Equals(one.Address.ZipCode, other.Address.ZipCode, StringComparison.OrdinalIgnoreCase))
                return false;

            if (!string.Equals(one.Address.City, other.Address.City, StringComparison.OrdinalIgnoreCase))
                return false;

            var streetOne = NormalizeStreet(one.Address.Street);
            var streetOther = NormalizeStreet(other.Address.Street);
            if (!string.Equals(streetOne, streetOther, StringComparison.OrdinalIgnoreCase))
                return false;

            var stateOne = NormalizeState(one.Address.State);
            var stateOther = NormalizeState(other.Address.State);
            if (!string.Equals(stateOne, stateOther, StringComparison.OrdinalIgnoreCase))
                return false;

            return true;
        }

        public int GetHashCode([DisallowNull] IAddress obj)
        {
            int hashcode = 1430287;
            hashcode = hashcode * 7302013 ^ obj.Address.ZipCode.GetHashCode();
            hashcode = hashcode * 7302013 ^ obj.Address.City.GetHashCode();
            hashcode = hashcode * 7302013 ^ NormalizeStreet(obj.Address.Street).GetHashCode();
            hashcode = hashcode * 7302013 ^ NormalizeState(obj.Address.State).GetHashCode();
            return hashcode;
        }
    }
}
