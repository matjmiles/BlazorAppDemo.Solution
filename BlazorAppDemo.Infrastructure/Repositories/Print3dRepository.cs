using AutoMapper;
using BlazorAppDemo.Shared.Print3dModels;
using Library.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Infrastructure.Repositories
{
    public class Print3dRepository : IPrint3dRepository
    {

        private readonly IDbContextFactory<Print3dContext> _print3DContext;
        private readonly IMapper _mapper;

        public Print3dRepository(IDbContextFactory<Print3dContext> print3dContext, IMapper mapper)
        {
            // these two variables can be used in all functions on this page
            _print3DContext = print3dContext;
            _mapper = mapper;
        }


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