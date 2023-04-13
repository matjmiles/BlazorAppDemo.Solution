## CRUD Operations for Table with Foreign Key Relationship

We are going to create CRUD operations for the Status table. Before you
can do this step, you must complete all of the previous steps associated with 
Initializing the project, and creating all of the CRUD operations for the Email 
table.

Let's review the steps we did earlier when we created the Email CRUD operations.

1. As a review we first created the entity for the status table.
```
namespace BlazorAppDemo.Core.Entities;

public class Status
{

    public int StatusId { get; set; }
    public string Name { get; set; }
    public bool AcceptPayment { get; set; }
    public bool InQueue { get; set; }
    public bool PatronCanDelete { get; set; }
    public bool DisplayOnDashboard { get; set; }
    public bool SubtractInventory { get; set; }
    public bool Completed { get; set; }
    public int? Order { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Status has a list of email
    public int? EmailId { get; set; }
    public virtual Email Email { get; set; }
```
* The fields of the Status table are defined with getters and setters.
* To create the FK relationship we define the FK in Status as the same 
name as the primary key in the Email table.
* You must add `public virtual Email Email { get; set; }` to complete 
the FK relationship.

2. Earlier we also created a Model for the Status table. Notice it is almost 
the same as the Entity.
```
namespace BlazorAppDemo.Shared.Print3dModels;

public partial class StatusModel
{
    public int StatusId { get; set; }
    public string Name { get; set; }
    public bool AcceptPayment { get; set; }
    public bool InQueue { get; set; }
    public bool PatronCanDelete { get; set; }
    public bool DisplayOnDashboard { get; set; }
    public bool SubtractInventory { get; set; }
    public bool Completed { get; set; }
    public int? Order { get; set; }
    public DateTime UpdatedAt { get; set; }

    // foreign key relationship
    public int? EmailId { get; set; }
    public virtual EmailModel Email { get; set; }
}

```
3. Create the Mapping in **BlazorAppDemo.Infrastructure.MappingProfile.cs**
```
using AutoMapper;
using BlazorAppDemo.Core.Entities;
using BlazorAppDemo.Shared.Print3dModels;

namespace BlazorAppDemo.Server.BazorAppDemo.Infrastructure;

public class MappingProfile : Profile{
    public MappingProfile()
    {
        CreateMap<Email, EmailModel>().ReverseMap();
        CreateMap<Status, StatusModel>().ReverseMap();

    }
}
```
4. Add a Fluent Validation file titled StatusValidator.cs in 
**BlazorAppDemo.Infrastructure.Validators**
```
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
```
5. We added the

