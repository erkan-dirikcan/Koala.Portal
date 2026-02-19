using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }


    public async Task<Response<UserInfoViewModel>> GetUserInfoById(string id)
    {
        try
        {
            var res = await _userRepository.GetUserInfoById(id);
            return res == null ?
                Response<UserInfoViewModel>.FailData(404, "Kullanıcı Bilgileri Alınırken Bir Sorunla Karşılaşıldı", "Kullanıcı Bilgileri Veri Tabanında Bulunamadı", true) :
                Response<UserInfoViewModel?>.SuccessData(200, "Kullanıcı Bilgileri Başarıyla Alındı", _mapper.Map<UserInfoViewModel>(res!));
        }
        catch (Exception ex)
        {
            return Response<UserInfoViewModel>.FailData(400, "Kullanıcı Bilgileri Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response<UserInfoViewModel>> GetUserInfoByEmail(string email)
    {
        try
        {
            var res = await _userRepository.GetUserInfoByEmail(email);
            return res == null ?
                Response<UserInfoViewModel>.FailData(404, "Kullanıcı Bilgileri Alınırken Bir Sorunla Karşılaşıldı", "Kullanıcı Bilgileri Veri Tabanında Bulunamadı", true) :
                Response<UserInfoViewModel?>.SuccessData(200, "Kullanıcı Bilgileri Başarıyla Alındı", _mapper.Map<UserInfoViewModel>(res!));
        }
        catch (Exception ex)
        {
            return Response<UserInfoViewModel>.FailData(400, "Kullanıcı Bilgileri Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response<UserInfoViewModel>> GetUserInfoByOid(string oid)
    {
        try
        {
            var res = await _userRepository.GetUserInfoByOid(oid);
            return res == null ?
                Response<UserInfoViewModel>.FailData(404, "Kullanıcı Bilgileri Alınırken Bir Sorunla Karşılaşıldı", "Kullanıcı Bilgileri Veri Tabanında Bulunamadı", true) :
                Response<UserInfoViewModel?>.SuccessData(200, "Kullanıcı Bilgileri Başarıyla Alındı", _mapper.Map<UserInfoViewModel>(res!));
        }
        catch (Exception ex)
        {
            return Response<UserInfoViewModel>.FailData(400, "Kullanıcı Bilgileri Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }

    public async Task<Response<List<UserListViewModel>>> GetUserActiveList()
    {
        try
        {
            var res = await _userRepository.GetUserActiveList();
            return res == null ? 
                Response<List<UserListViewModel>>.FailData(404, "Kullanıcı Listesi Alınırken Bir Sorunla Karşılaşıldı", "Sorgu sonrası hiç bir kullanıcı verisine ulaşılamadı. Veri Tabanı Ayarlarını Kontrol Ediniz", false) : 
                Response<List<UserListViewModel>>.SuccessData(200, "Kullanıcı Listesi Başarıyla Alındı", _mapper.Map<List<UserListViewModel>>(res));
        }
        catch (Exception ex)
        {
            return Response<List<UserListViewModel>>.FailData(400, "Kullanıcı Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
        }
    }
}