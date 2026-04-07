using FluentValidation;
using FluentValidation.TestHelper;
using Uzbekistan.Pinfl.FluentValidation.Extensions;

namespace Uzbekistan.Pinfl.FluentValidation.Tests;

public class PinflValidatorTests
{
    private readonly InlineValidator<TestModel> _validator;

    public PinflValidatorTests()
    {
        _validator = new InlineValidator<TestModel>();
        _validator.RuleFor(x => x.Pinfl).Pinfl();
    }

    [Theory]
    [InlineData("30101900010018")]
    [InlineData("50101010010010")]
    public void Pinfl_Should_Be_Valid(string pinfl)
    {
        var result = _validator.TestValidate(new TestModel { Pinfl = pinfl });
        result.ShouldNotHaveValidationErrorFor(x => x.Pinfl);
    }

    [Theory]
    [InlineData("123")]             // Juda qisqa
    [InlineData("30101900010010")]  // Checksum noto'g'ri
    [InlineData("90101900010015")]  // Prefix (9) noto'g'ri
    [InlineData("33201900010015")]  // Kun (32) noto'g'ri
    [InlineData("30113900010015")]  // Oy (13) noto'g'ri
    public void Pinfl_Should_Have_Error(string pinfl)
    {
        var result = _validator.TestValidate(new TestModel { Pinfl = pinfl });
        result.ShouldHaveValidationErrorFor(x => x.Pinfl);
    }

    private class TestModel
    {
        public string Pinfl { get; set; } = string.Empty;
    }
}