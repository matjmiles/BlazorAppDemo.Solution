using BlazorAppDemo.Core.Interfaces;
using BlazorAppDemo.Shared.Print3dModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorAppDemo.Server.Pages.Admin.Statuses;

public partial class AddOrUpdateStatusDialog
{
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }

    [Parameter] public StatusModel statusModel { get; set; } = new StatusModel();

    [Parameter] public int? StatusId { get; set; }

    [Parameter] public int? EmailId { get; set; }

    public List<EmailModel> AllEmails { get; set; }

    public int? SelectedEmailId { get; set; }

    public string SaveError { get; set; }


    [Inject] private IPrint3dRepository DataService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (statusModel.EmailId == null)
        {
            SelectedEmailId = 0;
        }
        else
        {
            SelectedEmailId = statusModel.EmailId;
        }

        AllEmails = await DataService.GetEmailsAsync();
    }

    private void Cancel()
    {
        MudDialog.Cancel();
    }

    protected async Task Submit()
    {
        var dialog = DialogResult.Ok(statusModel);
        StatusModel statusMod = dialog.Data as StatusModel;

        if (statusModel.StatusId < 0)
        {
            try
            {
                await DataService.CreateStatusAsync(statusMod);
                MudDialog.Close();
            }

            catch (Exception ex)
            {
                SaveError = $"Error when saving Status:{ex.Message}";
                // Logger.LogError(ex, "Error when trying to save a purchase request");
            }

        }
        else
        {
            try
            {
                await DataService.UpdateStatusAsync(statusMod);
                MudDialog.Close();
            }

            catch (Exception ex)
            {
                SaveError = $"Error when saving Status:{ex.Message}";
                // Logger.LogError(ex, "Error when trying to save a purchase request");
            }

        }

    }

    public void ChangeEmailId(int? selected)
    {
        SelectedEmailId = selected;
        statusModel.EmailId = selected;

        this.StateHasChanged();
    }



}
