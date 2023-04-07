using BlazorAppDemo.Shared.Print3dModels;

namespace Library.Core.Interfaces;

public interface IPrint3dRepository
{



    // Emails
    Task<List<EmailModel>> GetEmails();

    Task CreateEmailAsync(EmailModel emailModel);

    Task UpdateEmailAsync(EmailModel emailModel);

    Task DeleteEmailAsync(int emailId);

    //Task<Object> GetEmailByIdAsync(int statusId);


    

    // Statuses
    Task<List<StatusModel>> GetStatuses();

    Task<List<StatusModel>> GetStatusesByEmailId(int emailId);

    Task CreateStatusAsync(StatusModel statusModel);

    Task UpdateStatusAsync(StatusModel statusModel);

    Task DeleteStatusAsync(int machineId);





 


  



}
