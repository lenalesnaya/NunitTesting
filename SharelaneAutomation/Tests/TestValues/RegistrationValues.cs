using Core.Utilities;

namespace SharelaneAutomation.Tests.TestValues
{
    internal static class RegistrationValues
    {
        internal static readonly string EmptyStringValue = "";

        internal static readonly string ZipCodeUnderlimitValue = FakerHelper.GetNumericStringRandomValue(4);
        internal static readonly string ZipCodeOverlimitValue = FakerHelper.GetNumericStringRandomValue(6);
        internal static readonly string ZipCodeIncorrectSymbolsValue = FakerHelper.GetAlphaNumericSpecialSymbolsStringRandomValue(5);

        internal static readonly string FirstAndLastNameMinLimitValue = FakerHelper.GetAlphabeticStringRandomValue(1);
        internal static readonly string FirstAndLastNameMaxLimitValue = FakerHelper.GetAlphabeticStringRandomValue(256);
        internal static readonly string FirstAndLastNameOverlimitValue = FakerHelper.GetAlphabeticStringRandomValue(257);
        internal static readonly string AlphabeticSpaceValue = FakerHelper.GetAlphabeticStringRandomValue(5) + FakerHelper.GetAlphabeticStringRandomValue(5);
        internal static readonly string CyrillicValue = FakerHelper.GetCyrillicLettersStringRandomValue(10);
        internal static readonly string AlphaSpecialSymbolsValue = FakerHelper.GetAlphaSpecialSymbolsStringRandomValue(10);
        internal static readonly string AlphaNumericValue = FakerHelper.GetAlphaNumericStringRandomValue(10);

        internal static readonly string EmailAlphaNumericValue = FakerHelper.GetAlphaNumericStringRandomValue(10) + "@mail.ru";
        internal static readonly string EmailLowAlphabeticValue = FakerHelper.GetAlphabeticStringRandomValue(10).ToLower() + "@mail.ru";
        internal static readonly string EmailMaxLimitValue = FakerHelper.GetAlphaNumericStringRandomValue(248) + "@mail.ru";
        internal static readonly string EmailOverlimitValue = FakerHelper.GetAlphaNumericStringRandomValue(249) + "@mail.ru";
        internal static readonly string EmailCyrillicValue = FakerHelper.GetCyrillicLettersStringRandomValue(10) + "@mail.ru";
        internal static readonly string EmailUpAlphabeticValue = FakerHelper.GetAlphabeticStringRandomValue(10).ToUpper() + "@mail.ru";
        internal static readonly string EmailWithoutDotValue = FakerHelper.GetAlphaNumericStringRandomValue(10) + "@mailru";
        internal static readonly string EmailWithoutDoggyValue = FakerHelper.GetAlphaNumericStringRandomValue(10) + "mail.ru";
        internal static readonly string EmailWithTwoDoggyValue = FakerHelper.GetAlphaNumericStringRandomValue(10) + "@@mail.ru";
        internal static readonly string EmailWithSpaceValue = FakerHelper.GetAlphaNumericStringRandomValue(10) + " @mail.ru";
        internal static readonly string EmailDoggyAndDotValue = "@.";

        internal static readonly string PasswordMinLimitValue = FakerHelper.GetAlphaNumericSpecialSymbolsStringRandomValue(4);
        internal static readonly string PasswordMaxLimitValue = FakerHelper.GetAlphaNumericSpecialSymbolsStringRandomValue(256);
        internal static readonly string PasswordOverlimitValue = FakerHelper.GetAlphaNumericSpecialSymbolsStringRandomValue(257);
        internal static readonly string PasswordUnderLimitValue = FakerHelper.GetAlphaNumericSpecialSymbolsStringRandomValue(3);
        internal static readonly string PasswordWithSpaceValue =
            FakerHelper.GetAlphaNumericSpecialSymbolsStringRandomValue(3) + " " + FakerHelper.GetAlphaNumericSpecialSymbolsStringRandomValue(3);
    }
}