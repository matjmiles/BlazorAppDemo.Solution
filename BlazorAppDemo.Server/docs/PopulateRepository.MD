## Populate a Repository With Database Queries

 
1. Add the following using statements to the top of the Print3dRepository.cs
file

```
using AutoMapper;
using FluentValidation;
using Library.Core.Entities.Print3D;
using Library.Core.Interfaces;
using Library.Infrastructure.Validators;
using Library.Shared.Print3dModels;
using Microsoft.EntityFrameworkCore;
```

2. Add the "IDbContextFactory" and "IMapper" to the ==Print3dRepository==
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

3. Now we are ready to create our first CRUD operation, a Read command
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

The function signature is `public async Task<List<EmailModel>> GetEmails()`
* Async means the function is asynchronous. This requires using the ==await== 
command in the body of the function
* The function is a `Task` the returns a list of `EmailModels`
* You invoke the `Task` by calling `GetEmails()`

`await using Print3dContext db = await _print3DContext.CreateDbContextAsync();`
* Since this is an asynchronous function you must use the `await` command
* `db` is the object that is initialized as a DbContext



