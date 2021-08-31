using FluentValidation;
using SocieteGenerale.Domain.Common;

namespace SocieteGenerale.Application.Features.Customers.Commands.AddNewCustomer
{
    public class AddNewCustomerValidator : AbstractValidator<AddNewCustomerCommand>
    {
        public AddNewCustomerValidator()
        {
            RuleFor(p => p.FirstName)
               .NotEmpty().WithMessage(ErrorMessage.REQUIRED_PROPERTY_NAME)
               .NotNull().MaximumLength(50);
            RuleFor(p => p.LastName)
               .NotEmpty().WithMessage(ErrorMessage.REQUIRED_PROPERTY_NAME)
               .NotNull().MaximumLength(50);
            RuleFor(p => p.DateOfBirth)
                .NotEmpty().WithMessage(ErrorMessage.REQUIRED_PROPERTY_NAME)
               .NotNull();
            RuleFor(p => p.Email)
               .NotEmpty().WithMessage(ErrorMessage.REQUIRED_PROPERTY_NAME)
               .NotNull().EmailAddress();
        }
    }
}
