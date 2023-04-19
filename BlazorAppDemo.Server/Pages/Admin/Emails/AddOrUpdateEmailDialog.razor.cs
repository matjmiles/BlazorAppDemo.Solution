using BlazorAppDemo.Core.Interfaces;
using BlazorAppDemo.Shared.Print3dModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorAppDemo.Server.Pages.Admin.Emails;

public partial class AddOrUpdateEmailDialog
{
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }

    [Parameter] public EmailModel emailModel { get; set; } = new EmailModel();

    [Inject] private IPrint3dRepository DataService { get; set; }

    public string SaveError { get; set; }

    
  
    
    
    private void Cancel()
    {
        MudDialog.Cancel();
    }

    protected async Task Submit()
    {
        var dialog = DialogResult.Ok<EmailModel>(emailModel);
        EmailModel? emailMod = dialog.Data as EmailModel;

        if (emailModel.EmailId == 0)
        {
            try
            {
                await DataService.CreateEmailAsync(emailMod);
                MudDialog.Close();
            }
            catch (Exception ex)
            {
                SaveError = $"Error creating Email:{ex.Message}";
            }

        }
        else
        {
            try
            {
                await DataService.UpdateEmailAsync(emailMod);
                MudDialog.Close();
            }

            catch (Exception ex)
            {
                SaveError = $"Error updating Email:{ex.Message}";
            }

        }

    }

}