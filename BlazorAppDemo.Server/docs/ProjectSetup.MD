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
<a name="#addprojectreferences"></a>

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

### Add the Required NuGet Packages

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
d. The _Layout.cshtml is shown below.
```
@using Microsoft.AspNetCore.Components.Web
@namespace BlazorAppDemo.Server.Pages
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="~/" />
    @*
        <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" />
    <link href="css/site.css" rel="stylesheet" />
    
    *@
    <link href="BlazorAppDemo.Server.styles.css" rel="stylesheet" />
    <component type="typeof(HeadOutlet)" render-mode="ServerPrerendered" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" rel="stylesheet" />
    <link href="_content/MudBlazor/MudBlazor.min.css" rel="stylesheet" />
</head>
<body>
    @RenderBody()

    <div id="blazor-error-ui">
        <environment include="Staging,Production">
            An error has occurred. This application may no longer respond until reloaded.
        </environment>
        <environment include="Development">
            An unhandled exception has occurred. See browser dev tools for details.
        </environment>
        <a href="" class="reload">Reload</a>
        <a class="dismiss">🗙</a>
    </div>

    <script src="_framework/blazor.server.js"></script>
    <script src="_content/MudBlazor/MudBlazor.min.js"></script>
</body>
</html>

### Configure the Layout Using MudBlazor
```
12. Add a ==MudLayout== to **BlazorAppDemo.Server.Shared.MainLayout.razor**<br/>
In the example below, I have created a layout with an app bar, side navigation, and
main content area. 
```
@using MudBlazor
@inherits LayoutComponentBase

<PageTitle>3D Print</PageTitle>
<MudThemeProvider />
<MudDialogProvider FullWidth="true" />
<MudSnackbarProvider />
<MudLayout>
    <MudAppBar Color="Color.Primary">
        <MudText Typo="Typo.h4">3DPrint Administration</MudText>
    </MudAppBar>
    <MudMainContent>
        <MudPaper Elevation="0">
            <MudDrawerContainer Style="height:1200px" Class="mud-height-full">               
                <MudDrawer Height="100%" Width="200px" @bind-Open="@openStart" Elevation="1" Variant="@DrawerVariant.Persistent">
                    <MudNavMenu>
                        <MudText Style="margin-top:10px; margin-left:15px;" Typo="Typo.h6">Admin Tasks</MudText>
                        <MudNavLink Href="/Admin/Emails" Match="NavLinkMatch.All" StartIcon="@Icons.Material.Filled.Email">Emails</MudNavLink>
                        <MudNavLink Href="/Admin/Statuses" Match="NavLinkMatch.All" StartIcon="@Icons.Material.Filled.Settings">Statuses</MudNavLink>
                    </MudNavMenu>
                </MudDrawer>
                @Body
            </MudDrawerContainer>
        </MudPaper>
    </MudMainContent>

</MudLayout>

@code {
    bool openStart = true;
}
```



