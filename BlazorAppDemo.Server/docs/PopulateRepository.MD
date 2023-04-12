## Populate a Repository With Database Queries

1. Register the Print3dRepository in ==Program.cs== under the line<br/>
**var builder = WebApplication.CreateBuilder(args);**
```
builder.Services.AddScoped<IPrint3dRepository, Print3dRepository>();
```


2. Add the following using statements to the top of the Print3dRepository.cs
file

```
using AutoMapper;
using BlazorAppDemo.Shared.Print3dModels;
using BlazorAppDemo.Core.Interfaces;
using BlazorAppDemo.Core.Entities;
using BlazorAppDemo.Infrastructure.Validators;
using Microsoft.EntityFrameworkCore;
```

3. Add the "IDbContextFactory" and "IMapper" to the ==Print3dRepository==
class definition as shown below

```
        private readonly IDbContextFactory<Print3dContext> _print3DContext;
        private readonly IMapper _mapper;

        public Print3dRepository(IDbContextFactory<Print3dContext> print3dContext, IMapper mapper)
        {
            // these two variables can be used in all functions on this page
            _print3DContext = print3dContext;
            _mapper = mapper;
        }
```
4. Create function definitions for all of the CRUD operations that you will use.
```
        //email functions
        public async Task<List<EmailModel>> GetEmailsAsync()
        {
            throw new NotImplementedException();
        }
  
        public async Task CreateEmailAsync(EmailModel emailModel)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEmailAsync(EmailModel emailModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteEmailAsync(int emailId)
        {
            throw new NotImplementedException();
        }

        // Status Functions
        public async Task<List<StatusModel>> GetStatusesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task CreateStatusAsync(StatusModel statusModel)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateStatusAsync(StatusModel statusModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteStatusAsync(int machineId)
        {
            throw new NotImplementedException();
        }


        public async Task<List<StatusModel>> GetStatusesByEmailIdAsync(int emailId)
        {
            throw new NotImplementedException();
        }




    }
```
5. Code out the first CRUD operation, a Read command
to get a list of emails using an asynchronous Task.
```
    // Email Functions 
    public async Task<List<EmailModel>> GetEmails()
    {
        await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
        List<Email> allEmails = db.Emails.ToList();
        return _mapper.Map<List<EmailModel>>(allEmails);

    }
```

The function signature. <br/> 
`public async Task<List<EmailModel>> GetEmails()`
* Async means the function is asynchronous. This requires using the ==await== 
command in the body of the function
* The function is a ==Task== the returns a list of ==EmailModels==
* You invoke the ==Task== by calling ==`GetEmails()`==

`await using Print3dContext db = await _print3DContext.CreateDbContextAsync();`
* Since this is an asynchronous function you must use the ==await== command
* ==db== is the object that is initialized as a ==DbContext==

`return _mapper.Map<List<EmailModel>>(allEmails);`
* Map the list of Email Entities to a list of EmailModels 
and popluate the ==allEmails== variable with the list.

6. Code out the Create Email function. 


The function signature.
```
public async Task CreateEmailAsync(EmailModel newEmail)
```
* The function is asynchronous
* The function takes a single argument that is an instance of an EmailModel
 
```
    await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
    Email emailEntity = _mapper.Map<Email>(newEmail);
    emailEntity.UpdatedAt = System.DateTime.Now;
```
* The db variable is a DbContext and can send an Linq formatted query to the database
* ==emailEntity== receives the data from newEmail. Remember that Models 
handle the data within the application. Now that we are passing data back 
to the database, we must pass it to an Entity which interacts with the 
database.
* Set the date/time of UpdatedAt field to now.


Add Fluent Validation. 
```
// make sure the database entity is valid
EmailValidator validator = new();
FluentValidation.Results.ValidationResult validatorResult = await validator.ValidateAsync(emailEntity);

if (validatorResult.Errors.Any()) // the database entity is not valid
{
    List<string> valErrors = validatorResult.Errors.Select(v => v.ErrorMessage).ToList();
    throw new Exception(string.Join("; ", valErrors));
}
```
* You create an instance of ==EmailValidator==
 that you defined earlier in ==BlazorAppDemo.Infrastructure.Validators==
* If an error is thrown, it will prevent database submission and display 
the list of validations that failed.

Below is the complete code for CreateEmailAsync.
```
    public async Task CreateEmailAsync(EmailModel newEmail)
    {
        await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
        Email emailEntity = _mapper.Map<Email>(newEmail);
        emailEntity.UpdatedAt = System.DateTime.Now;

        // make sure the database entity is valid
        EmailValidator validator = new();
        FluentValidation.Results.ValidationResult validatorResult = await validator.ValidateAsync(emailEntity);

        if (validatorResult.Errors.Any()) // the database entity is not valid
        {
            List<string> valErrors = validatorResult.Errors.Select(v => v.ErrorMessage).ToList();
            throw new Exception(string.Join("; ", valErrors));
        }

        db.Emails.Add(emailEntity);

       await db.SaveChangesAsync();
        
    }
```
* ==db.Emails.Add(emailEntity)== is the Linq synatax to insert a record
into a table.
* ==await db.SaveChangesAsync()== commits the transaction to the database

7. Code out the Email Update statement.


