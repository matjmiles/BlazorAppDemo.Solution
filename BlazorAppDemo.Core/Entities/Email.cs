namespace BlazorAppDemo.Core.Entities;

    public class Email
    {

    public int EmailId { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Status has a list of Emails
    public List<Status> Statuses { get; set; } = new List<Status>();

}

