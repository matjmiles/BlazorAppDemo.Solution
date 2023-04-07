## Creating a Repository of Database Queries

 
The Repository is where we manage the SQL queries that will be used in the application. 
We will create an interface class that implments the repository class.

1. Right click on the ==BlazorAppDemo.Core== class library > Add > New Folder <br/>
Name the directory "Interfaces"

2. Right click on the ==Interfaces== folder > Add > Class<br/>
Add a new Interface Class titled "IPrint3dRepository"

3. Populate the interface class with the CRUD function signatures that you will use for each Model
in your project as shown below.

```
using BlazorAppDemo.Shared.Print3dModels;

namespace BlazorAppDemo.Core.Interfaces;

public interface IPrint3dRepository
{
    // Emails
    Task<List<EmailModel>> GetEmails();

    Task CreateEmailAsync(EmailModel emailModel);

    Task UpdateEmailAsync(EmailModel emailModel);

    Task DeleteEmailAsync(int emailId);

    // Statuses
    Task<List<StatusModel>> GetStatuses();

    Task<List<StatusModel>> GetStatusesByEmailId(int emailId);

    Task CreateStatusAsync(StatusModel statusModel);

    Task UpdateStatusAsync(StatusModel statusModel);

    Task DeleteStatusAsync(int machineId);

}
```
2. Right click on ==BlazorAppDemo.Infrastructure== Add > New Folder 
> Name the folder "Repositories" <br/>
Right click on the ==Repositories== folder > Add > Class > Name the
class Print3dRepository.cs





