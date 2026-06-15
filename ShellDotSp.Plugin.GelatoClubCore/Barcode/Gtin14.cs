using System;
using System.Linq;

namespace ShellDotSp.Plugin.GelatoClubCore.Barcode
{
    public class Gtin14Result
    {
        public bool IsValid { get; set; }
        public string Gtin14 { get; set; }
        public bool CheckDigitCalculated { get; set; }
    }

    public static class Gtin14
    {
        public static string AppendGtin14CheckDigit(string gtin13WithoutCheck)
        {
            if (string.IsNullOrWhiteSpace(gtin13WithoutCheck))
                throw new ArgumentNullException(nameof(gtin13WithoutCheck));

            if (gtin13WithoutCheck.Length != 13)
                throw new ArgumentException("Il GTIN-14 senza check digit deve contenere esattamente 13 cifre.");

            int sum = 0;

            for (int i = 0; i < gtin13WithoutCheck.Length; i++)
            {
                char c = gtin13WithoutCheck[i];

                if (c < '0' || c > '9')
                    throw new ArgumentException("Il GTIN deve contenere solo cifre.");

                int digit = c - '0';

                // Per GTIN-14: sulle prime 13 cifre, da sinistra:
                // indice 0 peso 3, indice 1 peso 1, indice 2 peso 3, ecc.
                sum += (i % 2 == 0)
                    ? digit * 3
                    : digit;
            }

            int checkDigit = (10 - (sum % 10)) % 10;

            return gtin13WithoutCheck + checkDigit.ToString();
        }

        public static bool IsValidGtin14(string gtin14)
        {
            if (string.IsNullOrWhiteSpace(gtin14) || gtin14.Length != 14)
                return false;

            string expected = AppendGtin14CheckDigit(gtin14.Substring(0, 13));

            return gtin14 == expected;
        }

        public static Gtin14Result NormalizeGtin14(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));

            if (!value.All(char.IsDigit))
                throw new ArgumentException("Il GTIN deve contenere solo cifre.");

            // 13 cifre -> calcolo check digit
            if (value.Length == 13)
            {
                string gtin14 = AppendGtin14CheckDigit(value);

                return new Gtin14Result
                {
                    IsValid = true,
                    Gtin14 = gtin14,
                    CheckDigitCalculated = true
                };
            }

            // 14 cifre -> validazione
            if (value.Length == 14)
            {
                bool valid = IsValidGtin14(value);

                return new Gtin14Result
                {
                    IsValid = valid,
                    Gtin14 = value,
                    CheckDigitCalculated = false
                };
            }

            throw new ArgumentException("Il GTIN deve contenere 13 o 14 cifre.");
        }
    }
}
