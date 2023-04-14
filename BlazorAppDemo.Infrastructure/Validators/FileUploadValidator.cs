using BlazorAppDemo.Core.Entities;
using FluentValidation;

namespace BlazorAppDemo.Infrastructure.Validators;


public class FileUploadValidator : AbstractValidator<FileUpload>
{
    public FileUploadValidator()
    {
        RuleFor(e => e).NotNull().WithMessage("No FileUpload found");
        RuleFor(e => e.Name)
            .NotNull().NotEmpty().WithMessage("Name is required");
        RuleFor(e => e.FilePath)
            .NotNull().NotEmpty().WithMessage("FilePath is required");

    }

}

