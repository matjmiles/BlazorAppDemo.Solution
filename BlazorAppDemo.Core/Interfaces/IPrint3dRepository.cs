using BlazorAppDemo.Shared.Print3dModels;

namespace BlazorAppDemo.Core.Interfaces;

public interface IPrint3dRepository
{

    // Emails
    Task<List<EmailModel>> GetEmailsAsync();

    Task CreateEmailAsync(EmailModel emailModel);

    Task UpdateEmailAsync(EmailModel emailModel);

    Task DeleteEmailAsync(int emailId);

    //FileUploads
    Task<List<FileUploadModel>> GetFileModelsAsync();

    Task CreateFileUploadAsync(FileUploadModel fileUploadModel);

    Task UpdateFileUploadAsync(FileUploadModel fileUploadModel);

    Task DeleteFileUploadAsync(int fileId);




    // Statuses
    Task<List<StatusModel>> GetStatusesAsync();

    Task<List<StatusModel>> GetStatusesByEmailIdAsync(int emailId);

    Task CreateStatusAsync(StatusModel statusModel);

    Task UpdateStatusAsync(StatusModel statusModel);

    Task DeleteStatusAsync(int machineId);





 


  



}
