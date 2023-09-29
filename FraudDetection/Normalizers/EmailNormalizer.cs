namespace FraudDetection.Normalizers
{
    using FraudDetection.Entities;
    using System;
    using System.Text;

    internal class EmailNormalizer : INormalizer<IEmail>
    {
        public string Normalize(IEmail? input)
        {
            if (string.IsNullOrWhiteSpace(input?.Email))
                return string.Empty;

            if (!input.Email.Contains('@'))
                return input.Email;

            var builder = new StringBuilder();

            var mailParts = input.Email.Split('@');
            builder.Append(NormalizeUsername(mailParts.First()));
            builder.Append(mailParts.Skip(1));

            return builder.ToString().ToLower();
        }

        private string NormalizeUsername(string username)
        {
            return username.Replace(".", "").Split("+").First();
        }
    }
}
