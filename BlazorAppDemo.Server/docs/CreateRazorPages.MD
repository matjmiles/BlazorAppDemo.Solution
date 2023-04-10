## Create Razor Component (Web Templates

 
Razor components allow you to populate web templates dynamically with data. They
also support using The MudBlazor component library to format your pages
using C# instead of JavaScript.

1. Under the main project, ==BlazorAppDemo.Server== there is a directory
created by default titled ==Pages==. Delete the following default pages
that are created initially with the project.
* "Counter.razor"
* "FetchData.razor"

2. Under ==BlazorAppDemo.Server/Pages== create two sub-directories
* "Admin" - for administrative pages
* "Public" - for public facing pages

3. Under ==BlazorAppDemo.Server/Pages/Admin== create a sub-directory 
for each entity in your database. We will start with "Emails" and
"Statuses" The directory structure should now look like the image below.

![Create Project](/img/RazorPages/01Directory.png)

4. Our first razor component will contain a list of Emails. Right click on
the ==Pages/Admin/Emails== folder > Add > **Razor Component** (NOT razor page) <br/>
Name the page "Index.Razor"

5. Let's initialze the page:
a. `@page "/Admin/Emails"` - the page directive
b. `@using BlazorAppDemo.Shared.Print3dModels` - path to Models we will use on this page
c. `@using MudBlazor` - Include the MudBlazor NuGet package we installed earlier. 
 This is necessary in order to use MudBlazor templates.
d. `@inject Library.Core.Interfaces.IPrint3dRepository emailService` - Inject the
 ==Print3dRepository== so you can access the database functions.
e. `@inject IDialogService _dialogService;` - the ==IDialogService is a .net class
that we use to pass data between the index and detail page in a master-detail relationship.
 It is used in conjuction the a MudBlazor dialog box.
d. Remove the ==@code block==. We will instead code in a "code behind" file.


![Create Project](/img/RazorPages/02CreateListPage.png)

6. To create the code behind page, right click on the ==Pages > Admin > Emails==
 click Add > Class > name the code behind page the same name as the razor page
 but with ".cs" appended to it. So name the file "Index.razor.cs". You will notice
 the code behind page shows up as a child of "Index.razor".

 ![Create Project](/img/RazorPages/03CodeBehind.png)

 7. Change "**public class Index**" to "**public partial class Index**".

 8. ==Inject== the service to access the functions listed in ==IPrint3dRepository==

 ```
 [Inject] private IPrint3dRepository DataService { get; set; }
 ```

 9. Create a list of EmailModels and give the list a name.

 ```
 public List<EmailModel> AllEmails { get; set; }
 ```

 10. Create a variable to hold error messages in case our database calls fail.
 ```
 public string SaveError { get; set; }
 ```

 11. Create an ==OnInitializedAsync()== function that runs when the page first loads. 
 Inside this function, we want to get a list of all records from the ==Email== table. We
 place our database call inside of a try catch block. If the database call fails,
 the exception will be raised and populate the ==SaveError== variable.
 
 ```
    protected override async Task OnInitializedAsync()
    {
        try
        {
            AllEmails = await DataService.GetEmails();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Emails{ex.Message}";
          
        }
    }
```
12. Create empty tasks for Create, Update, and Delete Email.

```
    protected async Task CreateEmailAsync()
    {
    }
```

13. The  ==Index.razor.cs== now looks like the code below.

```
using BlazorAppDemo.Core.Interfaces;
using BlazorAppDemo.Shared.Print3dModels;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorAppDemo.Server.Pages.Admin.Emails;

public partial class Index
{

    [Inject] private IPrint3dRepository DataService { get; set; }
    public List<EmailModel> AllEmails { get; set; }
    public string SaveError { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            AllEmails = await DataService.GetEmails();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Emails{ex.Message}";

        }
    }

    protected async Task CreateEmailAsync()
    {
    }

    protected async Task UpdateEmailAsync(int EmailId)
    {
    }

    protected async Task DeleteEmailAsync(int EmailId)
    {
    }

 }
 ```

 14. Return to ==Index.razor==. We now begin adding MudBlazor components. 
 Create a button by adding a **MudContainer class** and **MudFab** component
 a. This button will call the CreateEmailAsync function. The logic for this function
 is contained in the Index.razor.cs code behind file and is associated with the
 ==@onclick== event.

 ```
 <MudContainer Class="d-flex justify-center mb-2">
    <MudFab Color="MudBlazor.Color.Primary" StartIcon="@Icons.Material.Filled.Add" Size="Size.Large" IconSize="Size.Large" Label="Add A New
    Email" Class="ma-2" @onclick="(e => CreateEmailAsync())" />
</MudContainer>
```

15. Create a table to hold a list of emails.
```
<MudTable Class="pa-10" Items="@AllEmails">
    <ToolBarContent>
        <MudText Typo="Typo.h6">Emails</MudText>
        <MudSpacer />
    </ToolBarContent>
    <HeaderContent>
        <MudTh Class="mlr-2">>EmailId</MudTh>
        <MudTh Class="mlr-2">Name</MudTh>
        <MudTh Class="mlr-2" >Subject</MudTh>
        <MudTh Class="mlr-2">Body</MudTh>
        <MudTh Class="mlr-2">Update</MudTh>
        <MudTh Class="mlr-2">Delete</MudTh>
    </HeaderContent>
    <RowTemplate>
        <MudTd DataLabel="Email#">@context.EmailId</MudTd>
        <MudTd DataLabel="Name">@context.Name</MudTd>
        <MudTd DataLabel="Subject">@context.Subject</MudTd>
        <MudTd DataLabel="Body">@context.Body</MudTd>

        <MudTd Datalabel="">
            <MudFab @onclick="@(()=>UpdateEmailAsync(@context.EmailId))" StartIcon="@Icons.Material.Filled.Edit" Color="MudBlazor.Color.Primary">
            </MudFab>
        </MudTd>
        <MudTd Datalabel="">
            <MudFab @onclick="@(()=>DeleteEmailAsync(@context.EmailId))" StartIcon="@Icons.Material.Filled.Delete" Color="MudBlazor.Color.Error">
            </MudFab>
        </MudTd>
    </RowTemplate>
    <PagerContent>
        <MudTablePager />
    </PagerContent>
</MudTable>
```
16. Create a **MudAlert** component to hold any error messages thrown during the rendering of this page.

```
@if (!string.IsNullOrEmpty(SaveError))
{
    <MudAlert Severity="Severity.Error" Class="mt-2" ShowCloseIcon="true" CloseIconClicked="() => { SaveError = string.Empty; }">
        @SaveError
    </MudAlert>
}
```

17. Here is the complete code for the ==Index.razor== page as it now stands
```
@page "/Admin/Emails"

@using BlazorAppDemo.Shared.Print3dModels
@using MudBlazor


@inject Library.Core.Interfaces.IPrint3dRepository emailService
@inject IDialogService _dialogService;


<MudContainer Class="d-flex justify-center mb-2">
    <MudFab Color="MudBlazor.Color.Primary" StartIcon="@Icons.Material.Filled.Add" Size="Size.Large" IconSize="Size.Large" Label="Add A New
   Email" Class="ma-2" @onclick="(e => CreateEmailAsync())" />
</MudContainer>

<MudTable Class="pa-10" Items="@AllEmails">
    <ToolBarContent>
        <MudText Typo="Typo.h6">Emails</MudText>
        <MudSpacer />
    </ToolBarContent>
    <HeaderContent>
        <MudTh Class="mlr-2">>EmailId</MudTh>
        <MudTh Class="mlr-2">Name</MudTh>
        <MudTh Class="mlr-2">Subject</MudTh>
        <MudTh Class="mlr-2">Body</MudTh>
        <MudTh Class="mlr-2">Update</MudTh>
        <MudTh Class="mlr-2">Delete</MudTh>
    </HeaderContent>
    <RowTemplate>
        <MudTd DataLabel="Email#">@context.EmailId</MudTd>
        <MudTd DataLabel="Name">@context.Name</MudTd>
        <MudTd DataLabel="Subject">@context.Subject</MudTd>
        <MudTd DataLabel="Body">@context.Body</MudTd>

        <MudTd Datalabel="">
            <MudFab @onclick="@(()=>UpdateEmailAsync(@context.EmailId))" StartIcon="@Icons.Material.Filled.Edit" Color="MudBlazor.Color.Primary">
            </MudFab>
        </MudTd>
        <MudTd Datalabel="">
            <MudFab @onclick="@(()=>DeleteEmailAsync(@context.EmailId))" StartIcon="@Icons.Material.Filled.Delete" Color="MudBlazor.Color.Error">
            </MudFab>
        </MudTd>
    </RowTemplate>
    <PagerContent>
        <MudTablePager />
    </PagerContent>
</MudTable>

@if (!string.IsNullOrEmpty(SaveError))
{
    <MudAlert Severity="Severity.Error" Class="mt-2" ShowCloseIcon="true" CloseIconClicked="() => { SaveError = string.Empty; }">
        @SaveError
    </MudAlert>
}
```

18. Return to ==Index.razor.cs==
 
19. Add the lines below to ==CreateEmailAsync()==.
a. Line 1 - setup a variable to hold parameters that will be passed to the MudDialog form
that will be used to create a new Email.
b. Line 2 = Add an instance of an emtpy EmailModel to parameters.
c. Line 3 = Pass the parameters to ==AddOrUpdateEmailDialog.razor== template and show the template.



```
1   var parameters = new DialogParameters();
2   parameters.Add("emailModel", new EmailModel());
3   var dialog = await _dialogService.Show<AddOrUpdateEmailDialog>("Create A New Email Entry", parameters).Result;
```
19. After the new Email is added and the MudDialog box is closed, we want to re-run our
search of all Emails so our new Email will show up in the list. So we re-execute the
query to get a list of Emails and repopulate the grid.
```
 try
        {
            AllEmails = await DataService.GetEmails();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Emails{ex.Message}";
            Logger.LogError(ex, "Error retreiving Emails");
        }
```

20. Add the lines below to ==UpdateEmailAsync()== before the try/catch statement.
a. Line 1 - setup a variable to hold parameters that will be passed to the MudDialog form
b. Line 2 - Ppopulate the ==emailNeedToUpdate== variable with the record matching the emailId
that was passed into the function.
c. Line 3 - Add an instance of an EmailModel with the record retreived on line 2.
d. Line 4 - Pass the parameters to ==AddOrUpdateEmailDialog.razor== template and show the template.


```
1  var parameters = new DialogParameters();
2  var emailNeedToUpdate = AllEmails.FirstOrDefault(_ => _.EmailId == EmailId);
3  parameters.Add("emailModel", emailNeedToUpdate);
4  var dialog = await _dialogService.Show<AddOrUpdateEmailDialog>("Update A Email", parameters).Result;```
```

 

