using System.ComponentModel.DataAnnotations;

namespace Ipma.Api.Validation;

public class NotInFutureAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int year && year > DateTime.UtcNow.Year)
        {
            return new ValidationResult(
                $"Year cannot be in the future. Current year: {DateTime.UtcNow.Year}.",
                [validationContext.MemberName!]);
        }

        return ValidationResult.Success;
    }
}
