namespace FluentValidation.Uzbekistan.Constants;

/// <summary>
///     <see href="https://lex.uz/ru/docs/-5955665">Lex.uz</see>
///     <see href="https://regulation.gov.uz/uz/document/10400">Regulation.gov.uz</see>
/// </summary>
public static class PinflConstants
{
    public const int Length = 14;

    public static readonly List<int> ForControlNumber = [7, 3, 1];
}