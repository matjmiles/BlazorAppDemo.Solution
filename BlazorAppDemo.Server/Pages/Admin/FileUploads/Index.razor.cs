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
        var dialog = await _dialogService.Show<AddOrUpdateFileUploadDialog>("Update A Email", parameters).Result;

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
