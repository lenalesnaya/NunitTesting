using Bogus;

namespace Core.Utilities
{
    public static class FakerHelper
    {
        private static readonly Faker faker = new();

        public static string GetAlphabeticStringRandomValue(int length)
        {
            var chars = "abcdefghijklmnopqrstuvwxyz";
            return faker.Random.String2(length, chars + chars.ToUpper());
        }

        public static string GetNumericStringRandomValue(int length)
        {
            return Convert.ToString(faker.Random.Digits(length, 0, 9))!;
        }

        public static string GetAlphaNumericStringRandomValue(int length)
        {
            return faker.Random.AlphaNumeric(length);
        }

        public static string GetAlphaSpecialSymbolsStringRandomValue(int length)
        {
            var chars = "abcdefghijklmnopqrstuvwxyz" + "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
            return faker.Random.String2(length, chars);
        }

        public static string GetAlphaNumericSpecialSymbolsStringRandomValue(int length)
        {
            return faker.Random.String(length, '!', '~');
        }

        public static string GetCyrillicLettersStringRandomValue(int length)
        {
            return faker.Random.String(length, 'А', 'я');
        }

        public static string GetSymbolsSpecifiedRangeStringRandomValue(int length, char minValue, char maxValue)
        {
            return faker.Random.String(length, minValue, maxValue);
        }
    }
}