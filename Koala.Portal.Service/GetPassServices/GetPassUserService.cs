using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.GetPassRepositories;
using Koala.Portal.Core.GetPassServices;
using Koala.Portal.Core.ViewModels.GetPassViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Koala.Portal.Service.GetPassServices;

public class GetPassUserService : IGetPassUserService
{
	private IGetPassUserRepository _repository;
    private readonly IMapper _mapper;

    public GetPassUserService(IGetPassUserRepository repository, IMapper mapper)
	{
		_repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<GetSummaryUserInfoViewModel>> GetUserInfoByIdAsync(string id)
    {
		try
		{
			var res = await _repository.GetUserInfoByIdAsync(id);
			if (res == null)
			{
                return Response<GetSummaryUserInfoViewModel>.FailData(404, "Get Pass Kullanıcı Bilgisi Alınırken Bir Sorunla Karşılaşıldı", "Bilgilerine Erişilmek İstenilen Kullanıcı Bulunamadı", true);
            }
			var retVal = _mapper.Map<GetSummaryUserInfoViewModel>(res);
			return Response<GetSummaryUserInfoViewModel>.SuccessData(200, "GetPass Kullanıcı Bilgisi Başarıyla Alındı", retVal);
		}
		catch (Exception ex)
		{
			return Response<GetSummaryUserInfoViewModel>.FailData(400, "Get Pass Kullanıcı Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
		}
    }

    public async Task<Response<List<SelectListItem>>> GetUserSkeySelectListAsync(string? isSelected = "")
	{
		var res = (await _repository.GetAllAsyc()).Select(x => new SelectListItem{ Selected = x.SecretKey == isSelected, Text = $"{x.Name} {x.LastName}", Value = x.SecretKey }).ToList();
		return Response<List<SelectListItem>>.SuccessData(200, "GetPass Kullanıcı Listesi Başarıyla Alındı", res);
	}

    public async Task<Response<GetSummaryUserInfoViewModel>> GetUserInfoByEmailAsync(string email)
    {
        try
        {
            var res = await _repository.GetUserInfoByEmailAsync(email);
            if (res == null)
            {
                return Response<GetSummaryUserInfoViewModel>.FailData(404, "Get Pass Kullanıcı Bilgisi Alınırken Bir Sorunla Karşılaşıldı", "Bilgilerine Erişilmek İstenilen Kullanıcı Bulunamadı", true);
            }
            
            var retVal = _mapper.Map<GetSummaryUserInfoViewModel>(res);

            return Response<GetSummaryUserInfoViewModel>.SuccessData(200, "GetPass Kullanıcı Bilgisi Başarıyla Alındı", retVal);
        }
        catch (Exception ex)
        {
            return Response<GetSummaryUserInfoViewModel>.FailData(400, "Get Pass Kullanıcı Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response<GetSummaryUserInfoViewModel>> GetUserInfoBysKeyAsync(string sKey)
    {
        try
        {
            var res = await _repository.GetUserInfoBySkeyAsync(sKey);
            if (res == null)
            {
                return Response<GetSummaryUserInfoViewModel>.FailData(404, "Get Pass Kullanıcı Bilgisi Alınırken Bir Sorunla Karşılaşıldı", "Bilgilerine Erişilmek İstenilen Kullanıcı Bulunamadı", true);
            }

            var retVal = _mapper.Map<GetSummaryUserInfoViewModel>(res);

            return Response<GetSummaryUserInfoViewModel>.SuccessData(200, "GetPass Kullanıcı Bilgisi Başarıyla Alındı", retVal);
        }
        catch (Exception ex)
        {
            return Response<GetSummaryUserInfoViewModel>.FailData(400, "Get Pass Kullanıcı Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }
}