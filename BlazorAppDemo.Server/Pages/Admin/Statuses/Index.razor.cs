using BlazorAppDemo.Core.Interfaces;
using BlazorAppDemo.Shared.Print3dModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorAppDemo.Server.Pages.Admin.Statuses;

public partial class Index
{

    [Inject] private IPrint3dRepository DataService { get; set; }
    public List<StatusModel> AllStatuses { get; set; }
    public string SaveError { get; set; }

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

    protected async Task CreateStatusAsync()
    {
        var parameters = new DialogParameters();
        parameters.Add("statusModel", new StatusModel());
        var dialog = await _dialogService.Show<AddOrUpdateStatusDialog>("Create A New Status Entry", parameters).Result;

        try
        {
            AllStatuses = await DataService.GetStatusesAsync();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Statuses{ex.Message}";
        }
    }

    protected async Task UpdateStatusAsync(int statusId)
    {
        var parameters = new DialogParameters();
        var statusNeedToUpdate = AllStatuses.FirstOrDefault(_ => _.StatusId == statusId);
        parameters.Add("statusModel", statusNeedToUpdate);
        var dialog = await _dialogService.Show<AddOrUpdateStatusDialog>("Update A Status", parameters).Result;

        try
        {
            AllStatuses = await DataService.GetStatusesAsync();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Statuses{ex.Message}";
        }
    }

    protected async Task DeleteStatusAsync(int statusId)
    {
        bool? result = await _dialogService.ShowMessageBox(
        "Delete Confirmation",
        "Deleting can not be undone!",
        yesText: "Delete!", cancelText: "Cancel");

        if (result ?? false)
        {
            try
            {
                await DataService.DeleteStatusAsync(statusId);
                AllStatuses = await DataService.GetStatusesAsync();
            }
            catch (Exception ex)
            {
                SaveError = "You cannot delete this Status. It is attached to a job";
            }
        }
    }

}


