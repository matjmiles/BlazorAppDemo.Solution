## File Upload

We can use implement File Upload capability using the MudFileUpload component. We 
can use a simple intederminant progress indicator that will display while the 
file uploads.

1. 


1. Open the **BlazorAppDemo.Server.Pages.Admin.Emails.Index.razor.cs** file. Add the following lines.
```
private string searchString1 = "";
private EmailModel selectedItem1 = null;
private bool FilterFunc(EmailModel email, string searchString)
private bool FilterFunc1(EmailModel email) => FilterFunc(email, searchString1);

{
    if (string.IsNullOrWhiteSpace(searchString))
        return true;
    if (email.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
        return true;
    return false;
}
```
* **searchString1** is bound to a MudTextField and is the string to be searched
* **selectedItem1** is bound to the Filter
* **FilterFunc** 
* **FilterFunc1**
* Test to see if searchString is null
* Test to see if the searchString has a match in the table data

