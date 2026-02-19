using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.GetPassRepositories;
using Koala.Portal.Core.GetPassServices;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.ViewModels.GetPassViewModels;
using System.Numerics;

namespace Koala.Portal.Service.GetPassServices
{
    public class MyDataService : IMyDataService
    {
        private readonly IMyDataRepository _repository;
        private readonly IMapper _mapper;
        public MyDataService(IMyDataRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetPassGetUserInfoViewModels>>> GetMydataAsync(string UserId, BigInteger sKey)
        {
            var res=await _repository.GetMydataAsync(UserId);
            var retVal=new List<GetPassGetUserInfoViewModels>();
            var secret=Tools.BigIntToGuidStringPositive(sKey).Replace("-","");
            foreach (var item in res)
            {
               
                var model = new GetPassGetUserInfoViewModels
                {
                    Id = item.Id,
                    Description =string.IsNullOrEmpty(item.Description)?"": LicenceCryption.Decryption(item.Description, secret),
                    FirmName = string.IsNullOrEmpty(item.FirmName) ? "" : LicenceCryption.Decryption(item.FirmName, secret),
                    Name = string.IsNullOrEmpty(item.Name) ? "" : LicenceCryption.Decryption(item.Name, secret),
                    ServerType =item.ServerType==null?"": item.ServerType.TypeName,
                    VpnAplication = string.IsNullOrEmpty(item.VpnAplication) ? "" : LicenceCryption.Decryption(item.VpnAplication, secret)

                };
                retVal.Add(model);
            }
            return Response<List<GetPassGetUserInfoViewModels>>.SuccessData(200, "GetPass Datası Başarıyla Alındı", retVal);
        }

        public async Task<Response<GetPassGetLineInfoViewModel>> GetPassGetLineInfoAsync(string lineId, BigInteger sKey)
        {
            try
            {
                var secret = Tools.BigIntToGuidStringPositive(sKey).Replace("-", "");
                var res = await _repository.GetPassGetLineInfoAsync(lineId);
                var retVal = new GetPassGetLineInfoViewModel
                {
                    Ip = string.IsNullOrEmpty(res.Ip)?"": LicenceCryption.Decryption(res.Ip, secret),
                    LocalIp = string.IsNullOrEmpty(res.LocalIp)?"": LicenceCryption.Decryption(res.LocalIp, secret),
                    Password = string.IsNullOrEmpty(res.Password)?"": LicenceCryption.Decryption(res.Password, secret),
                    Port = string.IsNullOrEmpty(res.Port) ? "": LicenceCryption.Decryption(res.Port, secret),
                    UserName = string.IsNullOrEmpty(res.UserName) ? "" : LicenceCryption.Decryption(res.UserName,secret)
                };
                return Response<GetPassGetLineInfoViewModel>.SuccessData(200, "GetPass Satır Bilgisi Başarıyla Alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<GetPassGetLineInfoViewModel>.FailData(400, "GetPass Satır Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
           
        }
    }
}
