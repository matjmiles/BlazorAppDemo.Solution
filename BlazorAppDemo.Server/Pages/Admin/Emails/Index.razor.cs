using BlazorAppDemo.Core.Interfaces;
using BlazorAppDemo.Shared.Print3dModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorAppDemo.Server.Pages.Admin.Emails;

public partial class Index
{

    [Inject] private IPrint3dRepository DataService { get; set; }
    public List<EmailModel> AllEmails { get; set; }
    public string SaveError { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            AllEmails = await DataService.GetEmails();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Emails{ex.Message}";

        }
    }

    protected async Task CreateEmailAsync()
    {
        var parameters = new DialogParameters();
        parameters.Add("emailModel", new EmailModel());
        var dialog = await _dialogService.Show<AddOrUpdateEmailDialog>("Create A New Email Entry", parameters).Result;

        try
        {
            AllEmails = await DataService.GetEmails();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Emails{ex.Message}";
        }

    }

    protected async Task UpdateEmailAsync(int EmailId)
    {
        var parameters = new DialogParameters();
        var emailNeedToUpdate = AllEmails.FirstOrDefault(_ => _.EmailId == EmailId);
        parameters.Add("emailModel", emailNeedToUpdate);
        var dialog = await _dialogService.Show<AddOrUpdateEmailDialog>("Update A Email", parameters).Result;

        try
        {
            AllEmails = await DataService.GetEmails();
        }
        catch (Exception ex)
        {
            SaveError = $"Error retreiving Emails{ex.Message}";
        }
    }

    protected async Task DeleteEmailAsync(int EmailId)
    {
        bool? result = await _dialogService.ShowMessageBox(
        "Delete Confirmation",
        "Deleting can not be undone!",
        yesText: "Delete!", cancelText: "Cancel");

        if (result ?? false)
        {
            try
            {
                await DataService.DeleteEmailAsync(EmailId);
                AllEmails = await DataService.GetEmails();
            }
            catch (Exception ex)
            {
                SaveError = "You cannot delete this coupon. It is attached to a job";
            }
        }
    }
}