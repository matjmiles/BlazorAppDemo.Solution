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
a. `@page "/Admin/Emails"` = the page directive
b.`@using BlazorAppDemo.Shared.Print3dModels` = path to Models we will use on this page
c. `@using MudBlazor`


![Create Project](/img/RazorPages/02CreateListPage.png)

