using AutoMapper;
using BlazorAppDemo.Shared.Print3dModels;
using BlazorAppDemo.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using BlazorAppDemo.Core.Entities;
using BlazorAppDemo.Infrastructure.Validators;

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

        public async Task<List<EmailModel>> GetEmailsAsync()
        {
            await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
            List<Email> allEmails = db.Emails.ToList();
            return _mapper.Map<List<EmailModel>>(allEmails);
        }
        public async Task CreateEmailAsync(EmailModel emailModel)
        {
            await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
            Email emailEntity = _mapper.Map<Email>(emailModel);
            emailEntity.UpdatedAt = System.DateTime.Now;

            // make sure the database entity is valid
            EmailValidator validator = new();
            FluentValidation.Results.ValidationResult validatorResult = await validator.ValidateAsync(emailEntity);

            if (validatorResult.Errors.Any()) // the database entity is not valid
            {
                List<string> valErrors = validatorResult.Errors.Select(v => v.ErrorMessage).ToList();
                throw new Exception(string.Join("; ", valErrors));
            }
        }

        public async Task UpdateEmailAsync(EmailModel emailModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteEmailAsync(int emailId)
        {
            throw new NotImplementedException();
        }

        // Status functions
        public async Task<List<StatusModel>> GetStatusesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<StatusModel>> GetStatusesByEmailIdAsync(int emailId)
        {

            throw new NotImplementedException();
        }

        public async Task CreateStatusAsync(StatusModel statusModel)
        {
            throw new NotImplementedException();

        }
        public async Task UpdateStatusAsync(StatusModel statusModel)
        {
            throw new NotImplementedException();
        }



}



        public async Task DeleteStatusAsync(int machineId)
        {
            throw new NotImplementedException();
        }





        public async Task<List<StatusModel>> GetStatusesByEmailIdAsync(int emailId)
        {
            throw new NotImplementedException();
        }




    }
}