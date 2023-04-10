using BlazorAppDemo.Core.Interfaces;
using BlazorAppDemo.Shared.Print3dModels;
using Library.Core.Interfaces;
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
    }

    protected async Task UpdateEmailAsync(int EmailId)
    {
    }

    protected async Task DeleteEmailAsync(int EmailId)
    {
    }




 }
