using BlazorAppDemo.Core.Interfaces;
using BlazorAppDemo.Shared.Print3dModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorAppDemo.Server.Pages.Admin.Statuses;

public class Statuses
{

    [Inject] private IPrint3dRepository DataService { get; set; }

    public List<StatusModel> AllStatuses { get; set; }

    public string SaveError { get; set; }
}


