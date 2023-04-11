## Setting Up a Blazor Server Project

### Initialize the Project

1. Create a new Blazor Server App Project.

![Create Project](/img/ProjectSetup/01CreateProject.png)

2. Add 4 additional Class Libraries to the project by
right clicking on the project solution > Add > New Project.

![Class Libraries](/img/ProjectSetup/02AddClassLibraries.png)

3. Search for and select "Class Library.

![Add Class Library](/img/ProjectSetup/03AddClassLibrary.png)

4. Name the first Class Library BlazorAppDemo.Core and be
sure to have the correct project selected under location.

![Name Class Library](/img/ProjectSetup/04NameClassLibrary.png)

5. Create 2 more Class Libraries named
* BlazorAppDemo.Infrastructure
* BlazorAppDemo.Shared

![Project Explorer View](/img/ProjectSetup/05ProjectExplorer.png)

### Add Project References

1. Once you have created the project and class libraries, you must
create references between them. To do this, you must right click
on each project or class library > Add > Project Reference

![Project Explorer View](/img/ProjectSetup/08AddReferences1.png)

![Project Explorer View](/img/ProjectSetup/09AddReferences2.png)

2. Add project references as follows for the different class libraries 
and project.
a. BlazorAppDemo.Core: create reference to BlazorAppDemo.Shared

![Project Explorer View](/img/ProjectSetup/11CoreReference.png)

b. BlazorAppDemo.Infrastructure: create reference to BlazorAppDemo.Core

![Project Explorer View](/img/ProjectSetup/12InfrastructureReference.png)

c. BlazorAppDemo.Server: create reference to BlazorAppDemo.Infrastructure

![Project Explorer View](/img/ProjectSetup/13ServerReference.png)

d. BlazorAppDemo.Shared does not require any references.






### Add the Necessary NuGet Packages

6. Open the NuGet Package Manager.

![NuGet Menu](/img/ProjectSetup/06NugetMenu.png)

7. Under ==package.source== select "All" 

![NuGet Menu](/img/ProjectSetup/07NugetSearchAll.png)

8. In our solution **BlazorAppDemo** there is one project
called **BlazorAppDemo.Server**, and 3 class libraries
titled **BlazorAppDemo.Core**, **BlazorAppDemo.Infrastructure**, 
and **BlazorAppDemo.Server**. <br/><br/>
NuGet packages can be applied to any one or all of the projects
or class libraries.

9. The NuGet packages required for this project are
a. ==AutoMapper.Extensions.Microsoft.DependencyInjection==
b. ==FluentValidation==
c. ==Microsoft.EntityFraemworkCore==
d. ==Microsoft.EntityFrameworkCore.SqlServer==
e. ==Microsoft.EntityFrameworkCore.Tools==
e. ==Microsoft.Extensions.DependencyInjection.Abstractions==
f. ==MudBlazor==
g. ==Serilog.AspNetCore==

10. Register MudBlazor package in ==Program.cs== under:<br/>
**var builder = WebApplication.CreateBuilder(args);**
```
builder.Services.AddMudServices();
```
11. Add MudBlazor references in ==BlazorAppDemo.Server.Pages._Layout.cshtml
a. First comment out these lines as show below.
```
@*    
    <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" />
    <link href="css/site.css" rel="stylesheet" />
*@
```
b. Add the following lines under <br/>
**<component type="typeof(HeadOutlet)" render-mode="ServerPrerendered" />**
```
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" rel="stylesheet" />
    <link href="_content/MudBlazor/MudBlazor.min.css" rel="stylesheet" />
```
c. Just above the **</body>** tag add the line below:
```
    <script src="_content/MudBlazor/MudBlazor.min.js"></script>
```


