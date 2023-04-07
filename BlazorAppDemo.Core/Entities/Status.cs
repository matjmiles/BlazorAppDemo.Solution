namespace BlazorAppDemo.Core.Entities;

public class Status
{

    public int StatusId { get; set; }
    public string Name { get; set; }
    public bool AcceptPayment { get; set; }
    public bool InQueue { get; set; }
    public bool PatronCanDelete { get; set; }
    public bool DisplayOnDashboard { get; set; }
    public bool SubtractInventory { get; set; }
    public bool Completed { get; set; }
    public int? Order { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Status has a list of email
    public int? EmailId { get; set; }
    public virtual Email Email { get; set; }
}

