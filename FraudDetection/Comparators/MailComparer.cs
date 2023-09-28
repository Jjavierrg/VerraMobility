namespace FraudDetection.Comparators
{
    using FraudDetection.Entities;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    internal class MailComparer : IEqualityComparer<IEmail>
    { 
        public bool Equals(IEmail? one, IEmail? other)
        {
            if (one == null || other == null)
                return false;

            if (string.IsNullOrWhiteSpace(one.Email) || string.IsNullOrWhiteSpace(other.Email))
                return false;

            var mailOneParts = one.Email.Split('@');
            var mailOtherParts = one.Email.Split('@');

            string mailOneUsername = NormalizeUsername(mailOneParts[0]);
            string mailOneDomain = mailOneParts[1];

            string mailOtherUsername = NormalizeUsername(mailOtherParts[0]);
            string mailOtherDomain = mailOtherParts[1];

            if (!string.Equals(mailOneUsername, mailOtherUsername, StringComparison.OrdinalIgnoreCase))
                return false;

            if (!string.Equals(mailOneDomain, mailOtherDomain, StringComparison.OrdinalIgnoreCase))
                return false;

            return true;
        }

        public int GetHashCode([DisallowNull] IEmail obj) => obj.Email.GetHashCode();

        private string NormalizeUsername(string username)
        {
            return username.Replace(".", "").Split("+").First();
        }
    }
}
