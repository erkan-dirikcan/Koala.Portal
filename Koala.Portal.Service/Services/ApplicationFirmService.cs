using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using System.Collections.Generic;

namespace Koala.Portal.Service.Services
{
    public class ApplicationFirmService : IApplicationFirmService
    {
        private readonly IApplicationFirmRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        public ApplicationFirmService(IApplicationFirmRepository repository, IMapper mapper, IUnitOfWork<AppDbContext> unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> AddAsync(AddApplicationFirmsViewModel model)
        {
            try
            {
                var entity = _mapper.Map<ApplicationFirms>(model);
                await _repository.AddAsync(entity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Firma Uygulamaya Başarıyla Eklendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Firma uygulamaya Eklenirken Bir Sorunla Karşılaşıldı", ex.Message, false);

            }
        }

        public async Task<Response<List<GetApplicationFirmListViewModel>>> GetApplicationFirms(string applicationId)
        {
            try
            {
                var res = await _repository.GetApplicationFirms(applicationId);
                var retVal = _mapper.Map<List<GetApplicationFirmListViewModel>>(res);
                return Response<List<GetApplicationFirmListViewModel>>.SuccessData(200, "Uygulama Firma Listesi Başarıyla Alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<GetApplicationFirmListViewModel>>.FailData(400, "Uygulama firmalarının listesi alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response> UpdateExpDate(UpdateExpDateApplicationFirmsViewModel model)
        {
            try
            {
                var entity = await _repository.FindApplicationFirm(model.Id);
                entity.ExpDate = model.ExpDate;
                _repository.Update(entity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200,"Uygulama firmasının son kullanım tarihi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return Response.Fail(400,"uygulama Firması Güncellenirken Bir Sorunla Karşılaşıldı",ex.Message,false);
            }
        }
    }
}
