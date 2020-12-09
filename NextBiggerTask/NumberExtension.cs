using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NextBiggerTask
{
    public static class NumberExtension
    {
        /// <summary>
        /// Finds the nearest largest integer consisting of the digits of the given positive integer number and null if no such number exists.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>
        /// The nearest largest integer consisting of the digits  of the given positive integer and null if no such number exists.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when source number is less than 0.</exception>
        public static int? NextBiggerThan(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Thrown when source number is less than 0.");
            }

            return FindNext(number);
        }

        public static int? FindNext(int num)
        {
            var digits = num.ToString(CultureInfo.CurrentCulture).Select(t => int.Parse(t.ToString(), CultureInfo.CurrentCulture)).ToArray();
            List<int> lastDigit = new List<int>();
            string strNum = default;
            bool isNull = true;

            for (int i = digits.Length - 1; i > 0; i--)
            {
                if (digits[i] <= digits[i - 1])
                {
                    lastDigit.Add(digits[i]);
                    Array.Resize(ref digits, digits.Length - 1);
                }
                else
                {
                    lastDigit.Add(digits[i - 1]);
                    digits[i - 1] = digits[i];
                    Array.Resize(ref digits, digits.Length - 1);
                    lastDigit.Sort();
                    isNull = false;
                    break;
                }
            }

            foreach (var item in digits)
            {
                strNum += item;
            }

            foreach (var item in lastDigit)
            {
                strNum += item;
            }

            if (!int.TryParse(strNum, out var result) || isNull)
            {
                return null;
            }

            return result;
        }
    }
}
