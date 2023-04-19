## File Upload

Implement File Upload capability using the MudFileUpload component. Also, 
implement a simple intederminant progress indicator that will display while the 
file uploads.

### This tutorial implements file loading with the following conditions
* The file will be uploaded to a location on the webserver
* The path to the file will be stored in an entity with information about the
file including the filepath.

### This tutorial assumes
* A SQL table exists with a text field that can accept the file path
* The supporting model, entity, context, mapping, and validator have 
been created.
* Only one file can be loaded a time
* Only one file can be stored per database entry


### Instructions

1. Add a new folder titled **js** under **BlazorAppDemo.Server.wwwroot**

![Create Project](img/FileUploads/001Createjsfolder.png)

2. Add a new folder titled **submissions** under **BlazorAppDemo.Server.wwwroot**. This 
directory will hold the file submissions

3. Add a new file title **scripts.js** in the **js** folder with the following code.
```
window.triggerFileDownload = (fileName, url) => {
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    anchorElement.remove();
}
```

4. Create a new folder in **BlazorAppDemo.Server.Pages.Admin** titled "FileUploads"

![Create Project](img/FileUploads/01CreateFolder.png)

5. Create a new razor component titled "Index.razor" and populate the header.

```
@page "/Admin/FileUploads"

@using BlazorAppDemo.Core.Entities
@using BlazorAppDemo.Shared.Print3dModels

@inject BlazorAppDemo.Core.Interfaces.IPrint3dRepository FileUploadService
@using MudBlazor
@inject IDialogService _dialogService;
```


6. Add a code-behind for **Index.razor** titled **Index.razor.cs** and populate the header.
```
using BlazorAppDemo.Core.Interfaces;
using BlazorAppDemo.Shared.Print3dModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorAppDemo.Server.Pages.Admin.FileUploads;

public partial class Index
{

    [Inject] private IPrint3dRepository DataService { get; set; }
    public List<FileUploadModel> AllFileUploads { get; set; }
    public string SaveError { get; set; }

}
```
7. Create a razor component titled **AddOrUpdateFileUploadDialog.razor** in
****BlazorAppDemo.Server.wwwroot**** and populate the header.
```
@using BlazorAppDemo.Core.Interfaces;
@using BlazorAppDemo.Shared.Print3dModels;
@using Microsoft.AspNetCore.Components;
@using MudBlazor;

@inject IWebHostEnvironment env
@inject IJSRuntime JS
```
* Most of these using statements are familiar but we have introduced
 two new statements because we will need to interact with the JavaScript
 file we created earlier on the razor component.

8. Add a code-behind for **AddOrUpdateFileUploadDialog.razor** titled 
**AddOrUpdateFileUploadDialog.razor.cs** and populate the header.
```
using BlazorAppDemo.Core.Interfaces;
using BlazorAppDemo.Shared.Print3dModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;


namespace BlazorAppDemo.Server.Pages.Admin.FileUploads;
```

9. Add the **OnInitializedAsync()** function
```
    protected override async Task OnInitializedAsync()
    {
        try
        {
            AllFileUploads = await DataService.GetFileUploadsAsync();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Emails{ex.Message}";

        }
    }

```
10. Add the calls to the CRUD operations. 
```
    protected async Task CreateFileUploadAsync()
    {
        var parameters = new DialogParameters();
        parameters.Add("fileUploadModel", new FileUploadModel());
        var dialog = await _dialogService.Show<AddOrUpdateFileUploadDialog>("Create A New File Entry", parameters).Result;

        try
        {
            AllFileUploads = await DataService.GetFileUploadsAsync();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Emails{ex.Message}";
        }

    }

    protected async Task UpdateFileUploadAsync(int fileUploadId)
    {
        var parameters = new DialogParameters();
        var fileUploadNeedToUpdate = AllFileUploads.FirstOrDefault(_ => _.FileUploadId == fileUploadId);

        parameters.Add("fileUploadModel", fileUploadNeedToUpdate);
        var dialog = await _dialogService.Show<AddOrUpdateFileUploadDialog>("Update A File", parameters).Result;

        try
        {
            AllFileUploads = await DataService.GetFileUploadsAsync();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Emails{ex.Message}";
        }
    }

    protected async Task DeleteFileUploadAsync(int fileUploadId)
    {
        bool? result = await _dialogService.ShowMessageBox(
        "Delete Confirmation",
        "Deleting can not be undone!",
        yesText: "Delete!", cancelText: "Cancel");

        if (result ?? false)
        {
            try
            {
                await DataService.DeleteFileUploadAsync(fileUploadId);
                AllFileUploads = await DataService.GetFileUploadsAsync();
            }
            catch (Exception ex)
            {
                SaveError = "You cannot delete this file.";
            }
        }
    }
```
11. Below is the complete Code for **BlazorAppDemo.Server.Pages.Admin.Index.razor.cs
```
using BlazorAppDemo.Core.Interfaces;
using BlazorAppDemo.Shared.Print3dModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorAppDemo.Server.Pages.Admin.FileUploads;

public partial class Index
{

    [Inject] private IPrint3dRepository DataService { get; set; }
    public List<FileUploadModel> AllFileUploads { get; set; }
    public string SaveError { get; set; }



    protected override async Task OnInitializedAsync()
    {
        try
        {
            AllFileUploads = await DataService.GetFileUploadsAsync();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Emails{ex.Message}";

        }
    }

    protected async Task CreateFileUploadAsync()
    {
        var parameters = new DialogParameters();
        parameters.Add("fileUploadModel", new FileUploadModel());
        var dialog = await _dialogService.Show<AddOrUpdateFileUploadDialog>("Create A New File Entry", parameters).Result;

        try
        {
            AllFileUploads = await DataService.GetFileUploadsAsync();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Emails{ex.Message}";
        }

    }

    protected async Task UpdateFileUploadAsync(int fileUploadId)
    {
        var parameters = new DialogParameters();
        var fileUploadNeedToUpdate = AllFileUploads.FirstOrDefault(_ => _.FileUploadId == fileUploadId);

        parameters.Add("fileUploadModel", fileUploadNeedToUpdate);
        var dialog = await _dialogService.Show<AddOrUpdateFileUploadDialog>("Update A File", parameters).Result;

        try
        {
            AllFileUploads = await DataService.GetFileUploadsAsync();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Emails{ex.Message}";
        }
    }

    protected async Task DeleteFileUploadAsync(int fileUploadId)
    {
        bool? result = await _dialogService.ShowMessageBox(
        "Delete Confirmation",
        "Deleting can not be undone!",
        yesText: "Delete!", cancelText: "Cancel");

        if (result ?? false)
        {
            try
            {
                await DataService.DeleteFileUploadAsync(fileUploadId);
                AllFileUploads = await DataService.GetFileUploadsAsync();
            }
            catch (Exception ex)
            {
                SaveError = "You cannot delete this file.";
            }
        }
    }
}

```
12. Edit **BlazorAppDemo.Server.Pages.Admin.Index.razor** and
 add the MudBlazor components.
 ```
 <MudContainer Class="d-flex justify-center mb-2">
    <MudFab Color="MudBlazor.Color.Primary" StartIcon="@Icons.Material.Filled.Add" Size="Size.Large" IconSize="Size.Large" Label="Add A New
   File" Class="ma-2" @onclick="(e => CreateFileUploadAsync())" />
</MudContainer>

<MudTable Class="pa-10" Items="@AllFileUploads">
    <ToolBarContent>
        <MudText Typo="Typo.h6">Files</MudText>
        <MudSpacer />
    </ToolBarContent>
    <HeaderContent>
        <MudTh Class="mlr-2">FileUploadId</MudTh>
        <MudTh Class="mlr-2">Name</MudTh>
        <MudTh Class="mlr-2">File Path</MudTh>
    </HeaderContent>
    <RowTemplate>
        <MudTd DataLabel="FileUploadId#">@context.FileUploadId</MudTd>
        <MudTd DataLabel="Name">@context.Name</MudTd>
        <MudTd DataLabel="Subject">@context.FilePath</MudTd>
       

        <MudTd Datalabel="">
            <MudFab @onclick="@(()=>UpdateFileUploadAsync(@context.FileUploadId))" StartIcon="@Icons.Material.Filled.Edit" Color="MudBlazor.Color.Primary">
            </MudFab>
        </MudTd>
        <MudTd Datalabel="">
            <MudFab @onclick="@(()=>DeleteFileUploadAsync(@context.FileUploadId))" StartIcon="@Icons.Material.Filled.Delete" Color="MudBlazor.Color.Error">
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
13. Edit **BlazorAppDemo.Server.Pages.Admin.Index.razor** and add a
 **MudDialog** component and the text field for the file name
 ```
 <MudDialog>
    <DialogContent>
        <MudTextField T="string" Label="Name" @bind-Value="fileUploadModel.Name" />
    </DialogContent>
 </MudDialog>
```
14. Add the MudProgress bar
```
        @if (ShowProgressBar == true)
        {
            <MudProgressCircular Color="MudBlazor.Color.Primary" Size="Size.Large" Indeterminate="true" />
            <MudPaper>Loading file...</MudPaper>
        }
```
* ShowProgressBar variable is instantiated on the code-behind file. It initialized as false.
 Once the event handler for uploading a file is entered and a file is selected, it get set to
 true. Once the file upload is complete, it is set to false.

15.  Add a MudPaper class to hod the file upload button and text field to hold the file path.
```
<MudPaper Class="d-flex align-content-start flex-wrap flex-grow-1 gap-4" Elevation="0">

    <MudFileUpload T="IBrowserFile" Accept=".png, jpg, gif, docx, xlsx, txt, csv" OnFilesChanged="OnInputFileChange">
        <ButtonTemplate>
            <MudButton HtmlTag="label"
                        Variant="Variant.Filled"
                        Color="MudBlazor.Color.Primary"
                        StartIcon="@Icons.Material.Filled.CloudUpload"
                        for="@context">
                Upload File
            </MudButton>
        </ButtonTemplate>
    </MudFileUpload>

</MudPaper>
```
* The the type of IBrowser File on **MudFileUpload** is used when only a single file is to be uploaded.
* **Accept** is the list of file types that are allowed. The default is to allow all file types.
* **OnInputFileChange is a function that fires on the code-behind if the selected file changes.
* The Mudbutton sets the properties for the button.

16. Add code to conditionally show the **Download** button.
```
@if (@fileUploadModel.FilePath is not null)
{
    <MudButton HtmlTag="label"
            Variant="Variant.Filled"
            Color="MudBlazor.Color.Default"
            StartIcon="@Icons.Material.Filled.CloudDownload"
            OnClick="@(()=>DownloadFileFromURL(@fileUploadModel.FilePath))">
        Download File
    </MudButton>
```
* The conditional **@if** statement will be true and show the download button, if the
 FilePath value of the **FileUploadModel** instance has been populated.