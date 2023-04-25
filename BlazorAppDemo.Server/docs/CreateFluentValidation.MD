### [[Back to Index]](Index.MD)

## Setup Fluent Validation

 
Fluent Validation is a NuGet package that allows you to validate data before it
is submitted to the database to ensure that it follows all of the rules setup for
each table. During setup we already installed the Nuget packages **FluentValidation**
and **FluentValidation.DependencyInjectionExtensions**

1. Right click on BlazorAppDemo.Infrastructure > Add > New Folder > name the
folder "Validators"


2. Right click on the folder you just created, Validators > Add > Class >
create a class for each table using the naming convention Tablename + "Validator.
Since we only have two tables right now, we create a classes 
called "EmailValidator" and "StatusValidator"

3. A validator enforces the rules you define for an entity when you attempt to submit data
to the database. Below is the code for the Email entity. The most common rules are
enforcing a value for a field that does not allow nulls, or restricting to
a maximum length.

```
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
```

4. Repeat this process for the Status entity.