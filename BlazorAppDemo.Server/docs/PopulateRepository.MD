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
using Microsoft.EntityFrameworkCore;;
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
  public Task CreateEmailAsync(EmailModel emailModel)
        {
            throw new NotImplementedException();
        }

        public Task CreateStatusAsync(StatusModel statusModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmailAsync(int emailId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStatusAsync(int machineId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmailModel>> GetEmails()
        {
            throw new NotImplementedException();
        }

        public Task<List<StatusModel>> GetStatuses()
        {
            throw new NotImplementedException();
        }

        public Task<List<StatusModel>> GetStatusesByEmailId(int emailId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmailAsync(EmailModel emailModel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStatusAsync(StatusModel statusModel)
        {
            throw new NotImplementedException();
        }
    }
```
4. Create the first CRUD operation, a Read command
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

The function signature is: <br/> 
`public async Task<List<EmailModel>> GetEmails()`
* Async means the function is asynchronous. This requires using the ==await== 
command in the body of the function
* The function is a ==Task== the returns a list of ==EmailModels==
* You invoke the ==Task== by calling ==`GetEmails()`==

`await using Print3dContext db = await _print3DContext.CreateDbContextAsync();`
* Since this is an asynchronous function you must use the ==await== command
* ==db== is the object that is initialized as a ==DbContext==



