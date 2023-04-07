using BlazorAppDemo.Core.Entities;
using FluentValidation;

namespace Library.Infrastructure.Validators;


public class StatusValidator : AbstractValidator<Status>
{
    public StatusValidator()
    {
        RuleFor(e => e).NotNull().WithMessage("No Status found");
        RuleFor(e => e.Name)
            .NotNull().NotEmpty().WithMessage("Name is required")
            .MaximumLength(255).WithMessage("Name is limited to 255 characters");


    }
}
