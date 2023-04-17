## File Upload

We can use implement File Upload capability using the MudFileUpload component. We 
can use a simple intederminant progress indicator that will display while the 
file uploads.



1. Create a new folder in BlazorAppDemo.Server.Pages.Admin titled "FileUploads"

![Create Project](img/FileUploads/01RepositoryScaffold.png)

2. Create a new razor component titled "Index.razor" and populate the header:

```
@page "/Admin/FileUploads"


@using BlazorAppDemo.Core.Entities
@using BlazorAppDemo.Shared.Print3dModels


@inject BlazorAppDemo.Core.Interfaces.IPrint3dRepository FileUploadService
@using MudBlazor
@inject IDialogService _dialogService;
```
* The page directive
* Include path to Entities and Models
* Inject the IPrint3dRepository servive
* Indect the dialog service (necessary for a dialog box)

3. Add a code-behind for **Index.razor** titled **Index.razor.cs** 

