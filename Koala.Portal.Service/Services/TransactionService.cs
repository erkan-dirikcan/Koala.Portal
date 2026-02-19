using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Service.Services;

public class TransactionService(
    ITransactionRepository repository,
    IMapper mapper,
    IUnitOfWork<AppDbContext> unitOfWork,
    IGeneratedIdsService generatedIdsService,
    ITransactionItemRepository itemRepository)
    : ITransactionService
{
    public async Task<Response<List<TransactionListViewModel>>> GetTransactionList()
    {
        try
        {
            var res = repository.Where(x => x.IsComplated);
            var retVal = mapper.Map<List<TransactionListViewModel>>(await res.ToListAsync());
            return Response<List<TransactionListViewModel>>.SuccessData(200, "Transaction Listesi Başarıyla Alındı", retVal);
        }
        catch (Exception ex)
        {
            return Response<List<TransactionListViewModel>>.FailData(400, "Transaction Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response<List<TransactionListViewModel>>> GetModuleTransactionList(string moduleId)
    {
        try
        {
            var res = repository.Where(x => x.IsComplated && x.TransactionTypeId == moduleId);
            var retVal = mapper.Map<List<TransactionListViewModel>>(await res.ToListAsync());
            return Response<List<TransactionListViewModel>>.SuccessData(200, "Modül Transaction Listesi Başarıyla Alındı", retVal);
        }
        catch (Exception ex)
        {
            return Response<List<TransactionListViewModel>>.FailData(400, "Modül Transaction Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response<List<TransactionListViewModel>>> GetUserTransactionList(string userId)
    {
        try
        {
            var res = repository.Where(x => x.IsComplated && x.UserId == userId);
            var retVal = mapper.Map<List<TransactionListViewModel>>(await res.ToListAsync());
            return Response<List<TransactionListViewModel>>.SuccessData(200, "Kullanıcı Transaction Listesi Başarıyla Alındı", retVal);
        }
        catch (Exception ex)
        {
            return Response<List<TransactionListViewModel>>.FailData(400, "Kullanıcı Transaction Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response<TransactionListViewModel>> GetByIdAsync(string id)
    {
        try
        {
            var res = await repository.GetByIdAsync(id);
            var retVal = mapper.Map<TransactionListViewModel>(res);
            return Response<TransactionListViewModel>.SuccessData(200, "Transaction Bilgisi Başarıyla Alındı", retVal);
        }
        catch (Exception ex)
        {
            return Response<TransactionListViewModel>.FailData(400, "Transaction Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response> AddAsync(AddTransactionViewModel transaction)
    {
        try
        {
            var entity = mapper.Map<Transaction>(transaction);
            var nextId = await generatedIdsService.GetNextNumber("b89de5b0-70df-11ef-8301-00505684f38d");
            entity.TransactionNumber = nextId.Data;
            entity.CreateTime = DateTime.Now;
            entity.CreateUser = transaction.UserId ?? "";
            await repository.AddAsync(entity);
            await unitOfWork.CommitAsync();
            return Response.Success(200, "Transaction Başarıyla Eklendi");
        }
        catch (Exception ex)
        {
            return Response.Fail(400, "Transaction Eklenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response> AddItemAsync(AddTransactionItemViewModel model)
    {
        try
        {
            var entity = mapper.Map<TransactionItem>(model);
            await itemRepository.AddAsync(entity);
            await unitOfWork.CommitAsync();
            return Response.Success(200,"Transaction Item Başarıyla Eklendi");
        }
        catch (Exception ex)
        {
            return Response.Fail(400,"Transaction Item Eklenirken Bir Sorunla Karşılaşıldı",ex.Message,false);
        }
    }
}