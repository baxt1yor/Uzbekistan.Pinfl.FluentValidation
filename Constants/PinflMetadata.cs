namespace FluentValidation.Uzbekistan.Constants;

public record PinflCenturyRule(int BaseYear, bool IsMale);

public static class PinflMetadata
{
    public static readonly Dictionary<int, PinflCenturyRule> CenturyRules = new()
    {
        { 3, new PinflCenturyRule(1900, true) },  // 1900-1999 Male
        { 4, new PinflCenturyRule(1900, false) }, // 1900-1999 Female
        { 5, new PinflCenturyRule(2000, true) },  // 2000-2099 Male
        { 6, new PinflCenturyRule(2000, false) }, // 2000-2099 Female
        // You can easily add 7, 8, or 9 here for future centuries (2100, 2200, etc.)
    };
}