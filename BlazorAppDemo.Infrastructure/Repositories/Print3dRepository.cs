

using BlazorAppDemo.Shared.Print3dModels;
using Library.Core.Interfaces;

namespace BlazorAppDemo.Infrastructure.Repositories
{
    public class Print3dRepository : IPrint3dRepository
    {
        public Task CreateEmailAsync(EmailModel emailModel)
        {
            throw new NotImplementedException();
        }

        public Task CreateStatusAsync(StatusModel statusModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmailAsync(int emailId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStatusAsync(int machineId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmailModel>> GetEmails()
        {
            throw new NotImplementedException();
        }

        public Task<List<StatusModel>> GetStatuses()
        {
            throw new NotImplementedException();
        }

        public Task<List<StatusModel>> GetStatusesByEmailId(int emailId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmailAsync(EmailModel emailModel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStatusAsync(StatusModel statusModel)
        {
            throw new NotImplementedException();
        }
    }
}