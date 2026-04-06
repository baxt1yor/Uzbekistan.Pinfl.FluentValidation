using FluentValidation.Uzbekistan.Constants;

namespace FluentValidation.Uzbekistan.Validators;

public static class PinflValidator
{
    public static bool IsValid(string pinfl, out string? errorMessage)
    {
        errorMessage = null;

        if (string.IsNullOrWhiteSpace(pinfl) || pinfl.Length != PinflConstants.Length || !pinfl.All(char.IsDigit))
        {
            errorMessage = "PINFL must be exactly 14 digits.";
            return false;
        }

        var firstDigit = int.Parse(pinfl[0].ToString());
        if (!PinflMetadata.CenturyRules.TryGetValue(firstDigit, out var rule))
        {
            errorMessage = $"The prefix '{firstDigit}' is not a valid century/gender indicator.";
            return false;
        }

        try
        {
            var day = int.Parse(pinfl.Substring(1, 2));
            var month = int.Parse(pinfl.Substring(3, 2));
            var yearSuffix = int.Parse(pinfl.Substring(5, 2));
            var fullYear = rule.BaseYear + yearSuffix;

            if (month is < 1 or > 12 || day < 1 || day > DateTime.DaysInMonth(fullYear, month)) throw new Exception();
        }
        catch
        {
            errorMessage = "The birth date encoded in the PINFL is invalid.";
            return false;
        }

        var controlNumber = int.Parse(pinfl[^1].ToString());
        var sum = 0;
        for (var i = 0; i < 13; i++)
        {
            sum += int.Parse(pinfl[i].ToString()) * PinflConstants.ForControlNumber[i % 3];
        }

        if (sum % 10 == controlNumber) return true;
        errorMessage = "PINFL is invalid.";
        return false;
    }
}