using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ExchangeRateUpdater
{
    public static class ExchangeRateDeserializer
    {
        private const char _lineSeparator = '\n';
        private const char _lineValuesSeparator = '|';
        private const int _currencyCodeArrayPosition = 3;
        private const int _rateArrayPosition = 4;

        public static IEnumerable<ExchangeRate> DeserializeCNBExchangeRateString(string input)
        {
            var output = new List<ExchangeRate>();

            var inputLines = input.Split(_lineSeparator, StringSplitOptions.RemoveEmptyEntries).Skip(2);

            foreach (var line in inputLines)
            {
                var lineValues = line.Split(_lineValuesSeparator);

                var exchangeRate = new ExchangeRate(
                    new Currency("CZK"), 
                    new Currency(lineValues[_currencyCodeArrayPosition]),
                    decimal.Parse(lineValues[_rateArrayPosition], CultureInfo.GetCultureInfo("cs-CZ")));

                output.Add(exchangeRate);
            }

            return output;
        }
    }
}
