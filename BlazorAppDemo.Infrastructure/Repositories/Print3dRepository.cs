using AutoMapper;
using BlazorAppDemo.Shared.Print3dModels;
using BlazorAppDemo.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using BlazorAppDemo.Core.Entities;
using BlazorAppDemo.Infrastructure.Validators;
using Library.Infrastructure.Validators;
using Microsoft.AspNetCore.Http;

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

            db.Emails.Add(emailEntity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateEmailAsync(EmailModel emailModel)
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

            db.Emails.Update(emailEntity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteEmailAsync(int emailId)
        {
            await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
            var emailToRemove = await db.Emails.FindAsync(emailId);

            db.Emails.Remove(emailToRemove);
            await db.SaveChangesAsync();
        }

        // Status functions
        public async Task<List<StatusModel>> GetStatusesAsync()
        {
            await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
            List<Status> allStatuses = db.Statuses
                .Include(e => e.Email)
                .OrderBy(e => e.Email.Name)
                .ToList();
            return _mapper.Map<List<StatusModel>>(allStatuses);

        }

        public async Task<List<StatusModel>> GetStatusesByEmailIdAsync(int emailId)
        {
            await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
            List<Status> allStatuses =
                db.Statuses
                .Include(e => e.Email)
                .OrderBy(e => e.Email.Name)
                .Where(x => x.EmailId == emailId)
                .ToList();
            return _mapper.Map<List<StatusModel>>(allStatuses);

        }

        public async Task CreateStatusAsync(StatusModel statusModel)
        {
            await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
            Status statusEntity = _mapper.Map<Status>(statusModel);

            // make sure the database entity is valid
            StatusValidator validator = new();
            FluentValidation.Results.ValidationResult validatorResult = await validator.ValidateAsync(statusEntity);

            if (validatorResult.Errors.Any()) // the database entity is not valid
            {
                List<string> valErrors = validatorResult.Errors.Select(v => v.ErrorMessage).ToList();
                throw new Exception(string.Join("; ", valErrors));
            }

            statusEntity.UpdatedAt = System.DateTime.Now;

            db.Statuses.Add(statusEntity);
            await db.SaveChangesAsync();

        }
        public async Task UpdateStatusAsync(StatusModel statusModel)
        {

            await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
            Status statusEntity = _mapper.Map<Status>(statusModel);

            // make sure the database entity is valid
            StatusValidator validator = new();
            FluentValidation.Results.ValidationResult validatorResult = await validator.ValidateAsync(statusEntity);

            if (validatorResult.Errors.Any()) // the database entity is not valid
            {
                List<string> valErrors = validatorResult.Errors.Select(v => v.ErrorMessage).ToList();
                throw new Exception(string.Join("; ", valErrors));
            }

            statusEntity.UpdatedAt = System.DateTime.Now;

            db.Statuses.Update(statusEntity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteStatusAsync(int statusId)
        {
            await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
            var statusToRemove = await db.Statuses.FindAsync(statusId);

            db.Statuses.Remove(statusToRemove);
            await db.SaveChangesAsync();
        }

        public async Task<List<FileUploadModel>> GetFileUploadsAsync()
        {
            await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
            List<FileUpload> allFileUploads = db.FileUploads.ToList();
            return _mapper.Map<List<FileUploadModel>>(allFileUploads);
        }

        public async Task CreateFileUploadAsync(FileUploadModel fileUploadModel)
        {
            await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
            FileUpload fileUploadEntity = _mapper.Map<FileUpload>(fileUploadModel);
            

            // make sure the database entity is valid
            FileUploadValidator validator = new();
            FluentValidation.Results.ValidationResult validatorResult = await validator.ValidateAsync(fileUploadEntity);

            if (validatorResult.Errors.Any()) // the database entity is not valid
            {
                List<string> valErrors = validatorResult.Errors.Select(v => v.ErrorMessage).ToList();
                throw new Exception(string.Join("; ", valErrors));
            }

            db.FileUploads.Add(fileUploadEntity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateFileUploadAsync(FileUploadModel fileUploadModel)
        {
            await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
            FileUpload fileUploadEntity = _mapper.Map<FileUpload>(fileUploadModel);

            // make sure the database entity is valid
            FileUploadValidator validator = new();
            FluentValidation.Results.ValidationResult validatorResult = await validator.ValidateAsync(fileUploadEntity);

            if (validatorResult.Errors.Any()) // the database entity is not valid
            {
                List<string> valErrors = validatorResult.Errors.Select(v => v.ErrorMessage).ToList();
                throw new Exception(string.Join("; ", valErrors));
            }

            db.FileUploads.Update(fileUploadEntity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteFileUploadAsync(int fileUploadId)
        {
            await using Print3dContext db = await _print3DContext.CreateDbContextAsync();
            var fileUploadToRemove = await db.FileUploads.FindAsync(fileUploadId);

            db.FileUploads.Remove(fileUploadToRemove);
            await db.SaveChangesAsync();
        }
    }
}