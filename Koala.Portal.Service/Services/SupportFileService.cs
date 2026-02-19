using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Services;

public class SupportFileService: ISupportFileService
{
    private readonly IMapper _mapper;
    private readonly ISupportFileRepository _supportFileRepository;

    public SupportFileService(IMapper mapper, ISupportFileRepository supportFileRepository)
    {
        _mapper = mapper;
        _supportFileRepository = supportFileRepository;
    }

    public async Task<Response<GetSupportFileViewModel>> GetBySupportIdAsyc(string ticketId)
    {
        try
        {
            var res = _supportFileRepository.GetBySupportIdAsyc(ticketId);
            return Response<GetSupportFileViewModel>.SuccessData(200,"Destek Kaydı Dosyası Başarıyla Alındı",_mapper.Map<GetSupportFileViewModel>(res));
        }
        catch (Exception ex)
        {
            return Response<GetSupportFileViewModel>.FailData(400, "Dosya Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response<GetSupportFileViewModel>> GetByIdAsyc(string ticketId)
    {
        try
        {
            var res = _supportFileRepository.GetByIdAsyc(ticketId);
            return Response<GetSupportFileViewModel>.SuccessData(200, "Destek Kaydı Dosyası Başarıyla Alındı", _mapper.Map<GetSupportFileViewModel>(res));
        }
        catch (Exception ex)
        {
            return Response<GetSupportFileViewModel>.FailData(400, "Dosya Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }
}