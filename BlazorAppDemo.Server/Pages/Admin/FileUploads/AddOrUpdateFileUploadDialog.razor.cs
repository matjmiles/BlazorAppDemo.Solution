using BlazorAppDemo.Core.Interfaces;
using BlazorAppDemo.Shared.Print3dModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;


namespace BlazorAppDemo.Server.Pages.Admin.FileUploads;

public partial class AddOrUpdateFileUploadDialog
{
    [Inject] private IPrint3dRepository DataService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private ILogger<AddOrUpdateFileUploadDialog> Logger { get; set; }

    [CascadingParameter] MudDialogInstance MudDialog { get; set; }


    [Parameter] public FileUploadModel fileUploadModel { get; set; } = new FileUploadModel();

 

    public string SaveError { get; set; }
    public string FileSelectedMessage { get; set; }
    public bool FileSelected { get; set; } = false;
    public bool DisplayNoFileSelected { get; set; } = false;
    public bool ShowProgressBar { get; set; } = false;




    private void Cancel()
    {
        MudDialog.Cancel();
    }

    protected async Task Submit()
    {
        var dialog = DialogResult.Ok<FileUploadModel>(fileUploadModel);
        FileUploadModel fileUploadMod = dialog.Data as FileUploadModel;

        if (fileUploadModel.FileUploadId == 0)
        {
            try
            {
                await DataService.CreateFileUploadAsync(fileUploadMod);
                MudDialog.Close();
            }
            catch (Exception ex)
            {
                SaveError = $"Error creating File:{ex.Message}";
            }

        }
        else
        {
            try
            {
                await DataService.UpdateFileUploadAsync(fileUploadMod);
                MudDialog.Close();
            }

            catch (Exception ex)
            {
                SaveError = $"Error updating File:{ex.Message}";
            }

        }

    }

    // upload logic
    string Message = "No file selected";
    string theFileName = "";


    IBrowserFile? selectedFile;

    private async void OnInputFileChange(InputFileChangeEventArgs e)
    {

        if (fileUploadModel.FilePath != null)
            try
            {
                if (File.Exists(fileUploadModel.FilePath))
                {
                    File.Delete(fileUploadModel.FilePath);
                }

            }
            catch (Exception ex)
            {
                SaveError = $"Error deleting file:{ex.Message}";
                Logger.LogError(ex, "Error deleting file");

            }


        selectedFile = e.File;
        FileSelected = true;
        DisplayNoFileSelected = false;
        Message = $"{selectedFile.Name} file selected";

        if (selectedFile is not null)
        {
            ShowProgressBar = true;


            try
            {

                Stream stream = selectedFile.OpenReadStream(250000000);
                var fileName = $"{System.DateTime.Now.Ticks.ToString()}_{selectedFile.Name}";
                var filePath = $"{env.WebRootPath}\\submissions\\";
                var fullPath = Path.Combine(filePath, fileName);
                FileStream fs = File.Create(fullPath);
                await stream.CopyToAsync(fs);

                stream.Close();
                fs.Close();
                theFileName = fileName;
                fileUploadModel.FilePath = fullPath;

                Message = $"{selectedFile.Name} file uploaded to server";
                FileSelectedMessage = fileUploadModel.FilePath.Substring(@fileUploadModel.FilePath.LastIndexOf("\\") + 1);
                ShowProgressBar = false;
                this.StateHasChanged();


            }

            catch (Exception ex)
            {
                SaveError = $"Error uploading file:{ex.Message}";
                Logger.LogError(ex, "Error uploading file");

            }
            ShowProgressBar = false;

        }
        else
        {
            SaveError = $"No File Selected for Upload";
            DisplayNoFileSelected = true;
        }

    }

    // download logic
    private IJSObjectReference? module;

    // private string? result;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            module = await JS.InvokeAsync<IJSObjectReference>("import",
                "../js/scripts.js");
        }
    }

    private async Task DownloadFileFromURL(string fileUrl)
    {
        if (fileUrl is not null)
        {
            try
            {
                var startFileName = fileUrl.LastIndexOf("\\");
                var fileName = fileUrl.Substring(startFileName);
                var fileURL = "\\submissions\\" + fileName;
                await JS.InvokeVoidAsync("triggerFileDownload", fileName, fileURL);

            }
            catch (Exception ex)
            {
                SaveError = $"There is no file to download:{ex.Message}";
                Logger.LogError(ex, "There is no file to download");
            }
        }
        else
        {
            SaveError = $"There is no file to download.";
        }

    }


    private async void UploadFile()
    {

        if (selectedFile is not null)
        {
            ShowProgressBar = true;


            try
            {

                Stream stream = selectedFile.OpenReadStream(250000000);
                var fileName = $"{System.DateTime.Now.Ticks.ToString()}_{selectedFile.Name}";
                var filePath = $"{env.WebRootPath}\\submissions\\";
                var fullPath = Path.Combine(filePath, fileName);
                FileStream fs = File.Create(fullPath);
                await stream.CopyToAsync(fs);

                stream.Close();
                fs.Close();
                theFileName = fileName;
                fileUploadModel.FilePath = fullPath + Environment.NewLine + fullPath;

                Message = $"{selectedFile.Name} file uploaded to server";
                //FileSelectedMessage = FileSelectedMessage + Environment.NewLine + jobModel.FilePath.Substring(@jobModel.FilePath.LastIndexOf("\\") + 1);
                FileSelectedMessage = fileUploadModel.FilePath.Substring(@fileUploadModel.FilePath.LastIndexOf("\\") + 1);
                this.StateHasChanged();


            }

            catch (Exception ex)
            {
                SaveError = $"Error uploading file:{ex.Message}";
                Logger.LogError(ex, "Error uploading file");

            }
            ShowProgressBar = false;

        }
        else
        {
            SaveError = $"No File Selected for Upload";
            DisplayNoFileSelected = true;
        }
;
    }

}
