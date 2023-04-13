## Creating Razor Components for CRUD Operations

Razor components that handle FK relationships have the added complexity of
 associating lists of records from FK tables.

Let's review the steps we did earlier when we created the Email components.

1. Earlier we created a directory title "Statuses" under 
**BlazorAppDemo.Server.Pages.Admin**

![Create Project](img/RazorPages/01Directory.png)

### Create the Master or List Page 

2. Our razor component will contain a list of Statuses. Right click on
the **Pages/Admin/Emails** folder > Add > **Razor Component** (NOT razor page) <br/>
Name the page "Index.Razor"

3. Let's initialze the page:
a. `@page "/Admin/Statuses"` - the page directive
b. `@using BlazorAppDemo.Shared.Print3dModels` - path to Models we will use on this page
c. `@using MudBlazor` - Include the MudBlazor NuGet package we installed earlier. 
 This is necessary in order to use MudBlazor templates.
d. `@inject BlazorAppDemo.Core.Interfaces.IPrint3dRepository statusService` - Inject the
 **Print3dRepository** so you can access the database functions.
e. `@inject IDialogService _dialogService;` - the **IDialogService is a .net class
that we use to pass data between the index and detail page in a master-detail relationship.
 It is used in conjuction the a MudBlazor dialog box.
d. Remove the **@code block**. We will instead code in a "code behind" file.

Here is the code block.
```
@page "/Admin/Statuses"

@using BlazorAppDemo.Shared.Print3dModels
@using MudBlazor

@inject BlazorAppDemo.Core.Interfaces.IPrint3dRepository statusService
@inject IDialogService _dialogService;
```

![Create Project](img/FkRazor/01ListPage.png)

3. To create the code behind page, right click on the **Pages > Admin > Statuses**
 directory. Then click, Add > Class > name the code behind page the same name as the razor page
 but with ".cs" appended to it. So name the file "Index.razor.cs". You will notice
 the code behind page shows up as a child of "Index.razor".

![Create Project](img/FkRazor/02CodeBehind.png)

 7. Add the follwing using statements to the top of the code-behind page
```
using BlazorAppDemo.Core.Interfaces;
using BlazorAppDemo.Shared.Print3dModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;
```

8. Change "**public class Index**" to "**public partial class Index**".

9. Inside `public partial class Index` <br/>
 **Inject** the service to access the functions listed in **IPrint3dRepository**

 
 ```
 [Inject] private IPrint3dRepository DataService { get; set; }
 ```

 10. Create a list of StatusModels and give the list a name.

 ```
 public List<StatusModel> AllStatuses { get; set; }
 ```

 11. Create a variable to hold error messages in case our database calls fail.
 ```
 public string SaveError { get; set; }
 ```

 12. Create an **OnInitializedAsync()** function that runs when the page first loads. 
 Inside this function, we want to get a list of all records from the **Status** table. We
 place our database call inside of a try catch block. If the database call fails,
 the exception will be raised and populate the **SaveError** variable.
 
 ```
    protected override async Task OnInitializedAsync()
    {
        try
        {
            AllStatuses = await DataService.GetStatusesAsync();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Statuses{ex.Message}";
          
        }
    }
```
