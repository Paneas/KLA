using KLA.Conversion.Interfaces;
using KLA.Models.Resposne;
using System.Text;
using System.Text.RegularExpressions;

namespace KLA.Conversion.Services
{
    public sealed class ConvertService : IConvert
    {
        private readonly string[] Units = [ "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven",
                            "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" ];
        private readonly string[] Tens = ["", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"];
        private readonly string[] Thousands = ["", "thousand", "million"];
        private readonly string Cents = "cent";
        private readonly string Dollar = "dollar";

        public ConverNumberResponse ConvertNumberToWords(string number)
        {
            CheckNumber(number);
            StringBuilder sb = new StringBuilder();

            string[] tokens = number.Split(',');

            sb.Append(ConvertWholeNumber(tokens[0]));

            if (tokens.Length == 2)
                sb.Append(ConvertDecimals(tokens[1]));

            return new ConverNumberResponse()
            {
                Words = Regex.Replace(sb.ToString(), @"\s+", " ") //remove unnecessary spaces
            };
        }

        /// <summary>
        /// Validate the input
        /// </summary>
        /// <param name="number"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        private void CheckNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException();

            if (!Regex.IsMatch(number, "^\\-?[0-9]{1,9}(?:\\,[0-9]{1,2})?$"))
                throw new ArgumentException("Invalid format");
        }

        private string ConvertDecimals(string decimals)
        {
            StringBuilder sb = new StringBuilder(" and ");

            if (decimals.Length == 1)
                decimals = decimals + "0";

            int number = int.Parse(decimals);

            sb.Append(FindText(number));

            string s = number > 1 ? "s" : "";
            sb.Append($"{Cents}{s}");

            return sb.ToString();
        }

        private string ConvertWholeNumber(string wholeNumber)
        {
            StringBuilder sb = new StringBuilder();

            int number = int.Parse(wholeNumber);

            if (number == 0)
                return $"zero {Dollar}s";

            string s = number > 1 ? "s" : "";

            for (int i = 0; number > 0; i++)
            {
                if (number % 1000 != 0)
                    sb.Insert(0, FindText(number % 1000) + Thousands[i] + " ");

                number /= 1000;
            }

            sb.Append($" {Dollar}{s}");

            return sb.ToString();
        }

        private string FindText(int number)
        {
            StringBuilder sb = new StringBuilder();

            if (number >= 100)
            {
                sb.Append(Units[number / 100] + " hundred ");
                number %= 100;
            }

            if (number < 20)
                sb.Append(Units[number] + " ");
            else
            {
                string hyphen = number % 10 == 0 ? "" : "-";

                sb.Append(Tens[number / 10 - 1] + $"{hyphen}");
                sb.Append(Units[number % 10]);
            }
            sb.Append(' ');
            return sb.ToString();
        }
    }
}
