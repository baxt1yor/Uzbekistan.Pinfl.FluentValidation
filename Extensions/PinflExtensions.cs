using FluentValidation.Uzbekistan.Validators;

namespace FluentValidation.Uzbekistan.Extensions;

public static class PinflExtensions
{
    public static IRuleBuilderOptions<T, string> Pinfl<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return (IRuleBuilderOptions<T, string>)ruleBuilder.Custom((pinfl, context) =>
        {
            if (!PinflValidator.IsValid(pinfl, out var error))
            {
                context.AddFailure(error);
            }
        });
    }
}