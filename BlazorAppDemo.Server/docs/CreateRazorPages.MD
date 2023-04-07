## Create Razor Pages (Web Templates

 
Razor pages allow you to populate web templates dynamically with data. They
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


