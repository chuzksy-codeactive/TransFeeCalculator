using FluentValidation;
using TransFeeCalculator.Application.Models;

namespace TransFeeCalculator.Application.Validators
{
    public class AmountDTOValidator : AbstractValidator<AmountDTO>
    {
        public AmountDTOValidator()
        {
            RuleFor(a => a.Amount)
                .NotEmpty().WithMessage("Enter a valid value")
                .GreaterThan(0).WithMessage("Amount must be greater than 0");
        }
    }
}
