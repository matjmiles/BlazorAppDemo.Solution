using BlazorAppDemo.Core.Entities;
using FluentValidation;

namespace Library.Infrastructure.Validators;


public class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        RuleFor(e => e).NotNull().WithMessage("No email found");
        RuleFor(e => e.Name)
            .NotNull().NotEmpty().WithMessage("Name is required");
        RuleFor(e => e.Subject)
            .NotNull().NotEmpty().WithMessage("Subject is required");
        RuleFor(e => e.Body)
            .NotNull().NotEmpty().WithMessage("Body is required");

    }

}

