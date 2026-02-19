using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq.Expressions;




namespace Koala.Portal.Service.CrmServices
{
    public class CrmSupportService : ICrmSupportService
    {
        private readonly ICrmSupportRepository _repository;
        private readonly ICrmSqlService _crmSqlService;
        private readonly ICrmSupportStatesRepository _crmSupportStateRepository;
        private readonly ICrmSupportTypeRepository _crmSupportTypeRepository;
        private readonly ICrmFirmRepository _firmRepository;

        private readonly IUserRepository _userRepository;
        private readonly ICrmTicketHistoryRepository _ticketHistoryRepository;
        private readonly UserManager<AppUser> _userManager;
        //private readonly ICrmTicketHistoryRepository _crmSupportHistoryRepository;
        private readonly IMapper _mapper;
        public CrmSupportService(ICrmSupportRepository repository, IMapper mapper, UserManager<AppUser> userManager, ICrmSqlService crmSqlService, IUserRepository userRepository, ICrmTicketHistoryRepository ticketHistoryRepository, ICrmSupportStatesRepository crmSupportStateService, ICrmFirmRepository firmRepository, ICrmSupportTypeRepository crmSupportTypeRepository /*, ICrmTicketHistoryRepository crmSupportHistoryRepository*/)
        {
            _repository = repository;
            _mapper = mapper;
            _crmSqlService = crmSqlService;
            _userRepository = userRepository;
            _ticketHistoryRepository = ticketHistoryRepository;
            _crmSupportStateRepository = crmSupportStateService;
            _crmSupportTypeRepository = crmSupportTypeRepository;
            _firmRepository = firmRepository;
            _userManager = userManager;
            //_crmSupportHistoryRepository = crmSupportHistoryRepository;
        }
        public async Task<Response<List<CrmSupportListViewModel>>> Where(Expression<Func<MT_Ticket, bool>> predicate)
        {
            var retVal = await _repository.Where(predicate).ToListAsync();

            return Response<List<CrmSupportListViewModel>>.SuccessData(200,
                "Destek Kayıtlarının listesi başarıyla alındı", _mapper.Map<List<CrmSupportListViewModel>>(retVal));
        }
        public async Task<Response> AddAsyc(CrmCreateSupportViewModel model)
        {
            try
            {

                var tModel = _mapper.Map<MT_Ticket>(model);
                tModel.SpeCode = "Koala Portal";
                tModel.TicketId = GetNextTicketId();
                tModel.TicketState = new Guid("5D982B4A-4D94-43F2-960F-834743CBE1B0");
                await _repository.AddAsyc(tModel);


                return Response.Success(200, "Destek Kaydı Başarıyla Eklendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Destek Kaydı Oluşturlurken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
            return Response.Fail(400, "Destek Kaydı Oluşturlurken Bir Sorunla Karşılaşıldı", "", false);
        }
        public async Task<Response> TakeOnAsync(CreateCrmSupportTicketHistoryViewModel model)
        {
            try
            {
                var userOid = new Guid(model.UserOid);

                var entity = await _repository.FindByOidAsync(model.TicketOid);
                entity.DevamEdiyor = true;
                entity.ActiveWorkingUser = userOid;
                entity._LastModifiedBy = new Guid(model.UpdateUser);
                entity._LastModifiedDateTime = DateTime.Now;

                _repository.UpdateTicket(entity);
                var historyModel = new EX_Ticket_History
                {
                    Date_ = DateTime.Now,
                    Description = model.Description,
                    TicketId = entity.TicketId,
                    TicketOid = entity.Oid,
                    Oid = Tools.CreateGuid(),
                    UserOid = entity.ActiveWorkingUser
                };
                await _ticketHistoryRepository.AddAsync(historyModel);
                
                return Response.Success(200, "DestekKaydı Başarıyla ÜZerinize Alıundı");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Destek kaydı üzerinize alınırken bir sorunla karşılaşıldı.", ex.Message,
                    false);
            }

        }
        public async Task<Response<CheckTakeOnSupportResponseViewModel>> CheckTakeOn(string oid, string userOid)
        {
            try
            {
                #region Destek Kaydı Bilgisi
                var support = await _repository.FindByOidAsync(oid);
                if (support == null)
                {
                    return Response<CheckTakeOnSupportResponseViewModel>.FailData(404,
                        "Destek kaydı üzerinize alınırken bir sorunla karşılaşıldı", "Bilgilerine ulaşılmak istenilen destekj kaydı bulunamadı", true);
                }
                #endregion

                #region Web User veya Cevap Bekleyen
                //Kayıt portaldan veya cevap bekliyor olarak açılmış
                if (support.AssignedTo.ToString().Equals("A0EFF398-D31A-4767-A1DE-445312C9E086", StringComparison.OrdinalIgnoreCase) ||
                    support.AssignedTo.ToString().Equals("F2028B99-C49E-4F4B-B1E7-69FF7ACF869A", StringComparison.OrdinalIgnoreCase))
                {
                    //Kayıtla ilgili kimse çalışmıyor
                    if (support.ActiveWorkingUser == null)
                    {
                        var takeOnRes = await TakeOnAsync(new CreateCrmSupportTicketHistoryViewModel
                        {
                            TicketOid = oid,
                            UserOid = userOid,
                            Description = "",
                            UpdateUser = userOid

                        });
                        if (takeOnRes.IsSuccess)
                        {
                            return Response<CheckTakeOnSupportResponseViewModel>.SuccessData(200, "Destek Kaydını Başarıyla Üzerinize Aldınız", new CheckTakeOnSupportResponseViewModel
                            {
                                ContentDescription = "",
                                ContentTitle = "",
                                IsUpdated = true,
                                ModalTitle = "",
                                Oid = oid

                            });
                        }
                        else
                        {
                            return Response<CheckTakeOnSupportResponseViewModel>.FailData(400, takeOnRes.Message, takeOnRes.Errors.Errors, takeOnRes.IsSuccess);
                        }
                    }
                    //Kayıtla başkası çalışıyor
                    else if (!support.ActiveWorkingUser.ToString().Equals(userOid.ToUpper(), StringComparison.OrdinalIgnoreCase))
                    {
                        var workUser = await _userRepository.GetUserInfoByOid(support.ActiveWorkingUser.ToString());
                        return Response<CheckTakeOnSupportResponseViewModel>.SuccessData(200, "Destek Kaydını Başarıyla Üzerinize Aldınız", new CheckTakeOnSupportResponseViewModel
                        {
                            ContentDescription = $"{support.TicketId} numaralı destek kaydında {workUser.Name} {workUser.Lastname} isimli kullanıcı çalışıyor. ",
                            ContentTitle = $"Destek Kaydını Üzerinize Alıyorsunuz",
                            IsUpdated = false,
                            ModalTitle = $"{support.TicketId} Numaralı Destek Kaydını Üzerine Al",
                            Oid = oid,
                        });

                    }

                }

                #endregion
                #region Kullanıcıya Açılmış Kayıt
                //Kayıt kullanıcının üzerine
                else if (userOid.Equals(support.AssignedTo.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    //Kayıtla Kimse Çalışmıyor
                    var awu = support.ActiveWorkingUser?.ToString();
                    if (string.IsNullOrEmpty(awu))
                    {
                        var takeOnRes = await TakeOnAsync(new CreateCrmSupportTicketHistoryViewModel
                        {
                            Description = "",
                            UserOid = userOid,
                            TicketOid = oid,
                            UpdateUser = userOid
                        });
                        if (takeOnRes.IsSuccess)
                        {
                            return Response<CheckTakeOnSupportResponseViewModel>.SuccessData(200, "Destek Kaydını Başarıyla Üzerinize Aldınız", new CheckTakeOnSupportResponseViewModel
                            {
                                ContentDescription = "",
                                ContentTitle = "",
                                IsUpdated = true,
                                ModalTitle = "",
                                Oid = oid,
                            });
                        }
                        else
                        {
                            return Response<CheckTakeOnSupportResponseViewModel>.FailData(400, takeOnRes.Message, takeOnRes.Errors.Errors, takeOnRes.IsSuccess);
                        }
                    }
                    //Kayıtla başkası çalışıyor
                    //else if (support.ActiveWorkingUser.ToString().ToUpper() != userOid.ToUpper())
                    else if (!support.ActiveWorkingUser.ToString().Equals(userOid, StringComparison.OrdinalIgnoreCase))
                    {
                        var workUser = await _userRepository.GetUserInfoByOid(userOid);
                        return Response<CheckTakeOnSupportResponseViewModel>.SuccessData(200, "Destek Kaydını Başarıyla Üzerinize Aldınız", new CheckTakeOnSupportResponseViewModel
                        {
                            ContentDescription = $"{support.TicketId} numaralı size açılan destek kaydında {workUser.Name} {workUser.Lastname} isimli kullanıcı çalışıyor. ",
                            ContentTitle = $"Destek Kaydını Üzerinize Alıyorsunuz",
                            IsUpdated = false,
                            ModalTitle = $"{support.TicketId} Numaralı Destek Kaydını Üzerine Al",
                            Oid = oid
                        });
                    }
                    else
                    {

                        return Response<CheckTakeOnSupportResponseViewModel>.SuccessData(200, "Destek Kaydını Başarıyla Üzerinize Aldınız", new CheckTakeOnSupportResponseViewModel
                        {
                            ContentDescription = $"{support.TicketId} numaralı size açılan destek kaydının çalışan kullanıcısı zaten sizsiniz ",
                            ContentTitle = $"Destek Kaydı Zaten Adınıza Açılmış",
                            IsUpdated = false,
                            ModalTitle = $"{support.TicketId} Numaralı Destek Kaydını Üzerine Al",
                            Oid = oid
                        });
                    }
                }
                #endregion
                #region Başkasına Açılmış Kayıt
                //Kayıt Başkasının Adına
                else
                {
                    var workUser = await _userRepository.GetUserInfoByOid(support.ActiveWorkingUser.ToString());
                    var appointedUserId = support.AssignedTo?.ToString();
                    var appointedUser = await _userRepository.GetUserInfoByOid(appointedUserId);

                    //Kayıtla kimse çalışmıyor
                    if (support.ActiveWorkingUser == null)
                    {
                        //if (appointedUser != null)
                        //{
                        var crmUserList = _crmSqlService.GetCrmUserFullNameInfoList();
                        if (crmUserList != null)
                        {
                            return Response<CheckTakeOnSupportResponseViewModel>.SuccessData(200, "Destek Kaydını Başarıyla Üzerinize Aldınız", new CheckTakeOnSupportResponseViewModel
                            {
                                ContentDescription = $"{support.TicketId} numaralı Gereksiz Birisi adına açılan destek kaydını üzerinize alıyorsunuz. ",
                                ContentTitle = $"Destek Kaydını Üzerinize Alıyorsunuz",
                                IsUpdated = false,
                                ModalTitle = $"{support.TicketId} Numaralı Destek Kaydını Üzerine Al",
                                Oid = oid,
                            });
                        }
                        return Response<CheckTakeOnSupportResponseViewModel>.SuccessData(200, "Destek Kaydını Başarıyla Üzerinize Aldınız", new CheckTakeOnSupportResponseViewModel
                        {
                            ContentDescription = $"{support.TicketId} numara ile açılan destek kaydını üzerinize alıyorsunuz. ",
                            ContentTitle = $"Destek Kaydını Üzerinize Alıyorsunuz",
                            IsUpdated = false,
                            ModalTitle = $"{support.TicketId} Numaralı Destek Kaydını Üzerine Al",
                            Oid = oid,
                        });

                        //}
                        //return Response<CheckTakeOnSupportResponseViewModel>.SuccessData(200, "Destek Kaydını Başarıyla Üzerinize Aldınız", new CheckTakeOnSupportResponseViewModel
                        //{
                        //    ContentDescription = $"{support.TicketId} numaralı {appointedUser.Name} {appointedUser.Lastname} için açılan destek kaydını üzerinize alıyorsunuz. ",
                        //    ContentTitle = $"Destek Kaydını Üzerinize Alıyorsunuz",
                        //    IsUpdated = false,
                        //    ModalTitle = $"{support.TicketId} Numaralı Destek Kaydını Üzerine Al",
                        //    Oid = oid,
                        //});
                        return Response<CheckTakeOnSupportResponseViewModel>.SuccessData(200, "Destek Kaydını Başarıyla Üzerinize Aldınız", new CheckTakeOnSupportResponseViewModel
                        {
                            ContentDescription = $"{support.TicketId} numaralı Gereksiz Birisi adına açılan destek kaydını üzerinize alıyorsunuz. ",
                            ContentTitle = $"Destek Kaydını Üzerinize Alıyorsunuz",
                            IsUpdated = false,
                            ModalTitle = $"{support.TicketId} Numaralı Destek Kaydını Üzerine Al",
                            Oid = oid,
                        });
                    } //Kayıtla başkası çalışıyor
                    else if (!support.ActiveWorkingUser.ToString().Equals(userOid, StringComparison.OrdinalIgnoreCase))
                    {

                        //}
                        //else if (support.ActiveWorkingUser.ToString().ToUpper() != userOid.ToUpper())
                        //{
                        return Response<CheckTakeOnSupportResponseViewModel>.SuccessData(200, "Destek Kaydını Başarıyla Üzerinize Aldınız", new CheckTakeOnSupportResponseViewModel
                        {
                            ContentDescription = $"{support.TicketId} numaralı {workUser.Name} {workUser.Lastname} için açılan destek kaydında {workUser.Name} {workUser.Lastname} isimli kullanıcı çalışıyor. ",
                            ContentTitle = $"Destek Kaydını Üzerinize Alıyorsunuz",
                            IsUpdated = false,
                            ModalTitle = $"{support.TicketId} Numaralı Destek Kaydını Üzerine Al",
                            Oid = oid,
                        });

                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                return Response<CheckTakeOnSupportResponseViewModel>.FailData(400, "Destek kaydı üzerinize alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
            return Response<CheckTakeOnSupportResponseViewModel>.FailData(400, "Destek kaydı üzerinize alınırken bir sorunla karşılaşıldı", "Destek kaydı üzerinize alınırken bir sorunla karşılaşıldı", false);
        }
        public async Task<Response<List<CrmSupportListViewModel>>> GetFilteredSupports(CrmUserSupportFilterModel model)
        {
            try
            {
                var sDate = DateTime.ParseExact(model.StartDate, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                var eDate = DateTime.ParseExact(model.EndDate, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                var supports = await _repository.Where(x => x._LastModifiedDateTime >= sDate && x._LastModifiedDateTime <= eDate && x.GCRecord == null).ToListAsync();
                if (!string.IsNullOrEmpty(model.ActiveWorkingUserOid))
                {
                    var awu = new Guid(model.ActiveWorkingUserOid);
                    supports = supports.Where(x => x.ActiveWorkingUser == awu).ToList();
                }

                if (!string.IsNullOrEmpty(model.AppointedWorkingUserOid))
                {
                    var apu = new Guid(model.AppointedWorkingUserOid);
                    supports = supports.Where(x => x.AssignedTo == apu).ToList();

                }
                if (!string.IsNullOrEmpty(model.Firm))
                {
                    var firmGuid = new Guid(model.Firm);
                    supports = supports.Where(x => x.TicketFirm == firmGuid).ToList();
                }


                if (model.Statuses.Count > 0)
                {
                    supports = supports.Where(x => model.Statuses.Contains(x.TicketState.ToString() ?? string.Empty)).ToList();
                }

                var retVal = _mapper.Map<List<CrmSupportListViewModel>>(supports);
                return Response<List<CrmSupportListViewModel>>.SuccessData(200,
                    "Filtrelenmiş Destek Kayıtları Başarıyla Alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<CrmSupportListViewModel>>.FailData(400, "Filtrelenmiş Destek Kayıtları Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
        public async Task<Response<CrmUpdateSupportInfoViewModel>> GetUpdateSupportInfoAsync(string supportOid)
        {
            try
            {
                var support = await _repository.FindByOidAsync(supportOid);
                if (support == null)
                {
                    Response<CrmUpdateSupportInfoViewModel>.FailData(404,
                        "Güncellenmek İstenilen Destek Kaydı Bilgilerine Ulaşılamadı",
                        "Güncellenmek İstenilen Destek Kaydı Bilgilerine Ulaşılamadı", true);
                }
                var retVal = _mapper.Map<CrmUpdateSupportInfoViewModel>(support);
                return Response<CrmUpdateSupportInfoViewModel>.SuccessData(200, "Destek Kaydı Bilgisi Başarıyla Alındı", retVal);

            }
            catch (Exception ex)
            {
                return Response<CrmUpdateSupportInfoViewModel>.FailData(400,
                    "Destek Kaydı Bilgisi Alınırken Bir Sorunla Karşılaşıldı",
                    ex.Message, true);
            }

        }
        public async Task<Response> UpdateSupportAsync(CrmUpdateSupportViewModel model)
        {
            try
            {
                #region Gerekli Kayıt Bilgileri
                var support = await _repository.FindByOidAsync(model.Oid);
                var supportState = await _crmSupportStateRepository.GetByOidAsync(new Guid(model.TicketState));
                var tType = new Guid(model.TicketType);
                var supportType = await _crmSupportTypeRepository.GetByOidAsync(tType);
                var firm = _firmRepository.GetFirmSupportStatusInfo(support.TicketFirm.ToString());
                #endregion

                #region Departmana Göre Bakım Anlaşması Kontrolü
                if (support.AssignedDepartment.ToString().Equals("E86E6850-AFE2-47C9-9F8D-3C4E99518D63", StringComparison.OrdinalIgnoreCase))
                {
                    //Departman Logo İse
                    //Firma Logo Anlaşması Yok İse
                    if (((firm.FirmLogoBakimAnlasmasi != true && firm.FirmLogoBakimBitisTarihi < DateTime.Now) ||
                         (firm.FirmYeniLogoBakimAnlasmasi != true && firm.FirmYeniLogoBakimBitisTarihi < DateTime.Now))
                        &&model.TicketState.ToUpper() == "07D17E00-B999-4A39-8C01-4E0CEB1925FD")
                    {
                        return Response.Fail(400, "Firma Bakım Anlaşması Bulunmuyor, Ücretsiz Kapatamazsınız.", "Firma Bakım Anlaşması Bulunmuyor, Ücretsiz Kapatamazsınız.", true);
                    }

                }
                else if (support.AssignedDepartment.ToString().Equals("416184D2-ECE2-4265-860F-69DAA0DB07F3", StringComparison.OrdinalIgnoreCase))
                {
                    if (((firm.FirmTeknikBakimAnlasmasi != true && firm.FirmTeknikBakimBitisTarihi < DateTime.Now) ||
                        (firm.FirmYeniDonanimBakimAnlasmasi != true && firm.FirmYeniLogoBakimBitisTarihi < DateTime.Now))
                       && model.TicketState.ToUpper() == "07D17E00-B999-4A39-8C01-4E0CEB1925FD")
                    {
                        return Response.Fail(400, "Firma Bakım Anlaşması Bulunmuyor, Ücretsiz Kapatamazsınız.", "Firma Bakım Anlaşması Bulunmuyor, Ücretsiz Kapatamazsınız.", true);
                    }
                }
                //switch (support.AssignedDepartment.ToString()?.ToUpper())
                //{
                //    //Departman Logo İse
                //    //Firma Logo Anlaşması Yok İse
                //    case "E86E6850-AFE2-47C9-9F8D-3C4E99518D63" when firm.FirmLogoBakimAnlasmasi != true && firm.FirmYeniLogoBakimAnlasmasi != true && model.TicketState.ToUpper() == "07D17E00-B999-4A39-8C01-4E0CEB1925FD":
                //        return Response.Fail(400, "Firma Bakım Anlaşması Bulunmuyor, Ücretsiz Kapatamazsınız.", "Firma Bakım Anlaşması Bulunmuyor, Ücretsiz Kapatamazsınız.", true);
                //    //Firma Logo Destek Anlaşması Süresi Dolduysa
                //    case "E86E6850-AFE2-47C9-9F8D-3C4E99518D63" when firm.FirmLogoBakimBitisTarihi < DateTime.Now && firm.FirmYeniLogoBakimBitisTarihi < DateTime.Now && model.TicketState.ToUpper() == "07D17E00-B999-4A39-8C01-4E0CEB1925FD":
                //        return Response.Fail(400, "Firma Bakım Anlaşması Süresi Dolmuş, Ücretsiz Kapatamazsınız.", "Firma Bakım Anlaşması Süresi Dolmuş, Ücretsiz Kapatamazsınız.", true);
                //    //Departman Teknik İSe
                //    //Firma Logo Anlaşması Yok İse
                //    case "416184D2-ECE2-4265-860F-69DAA0DB07F3" when firm.FirmTeknikBakimAnlasmasi != true && firm.FirmYeniDonanimBakimAnlasmasi != true && model.TicketState.ToUpper() == "07D17E00-B999-4A39-8C01-4E0CEB1925FD":
                //        return Response.Fail(400, "Firma Bakım Anlaşması Bulunmuyor, Ücretsiz Kapatamazsınız.", "Firma Bakım Anlaşması Bulunmuyor, Ücretsiz Kapatamazsınız.", true);
                //    //Firma Logo Destek Anlaşması Süresi Dolduysa
                //    case "416184D2-ECE2-4265-860F-69DAA0DB07F3" when firm.FirmTeknikBakimBitisTarihi < DateTime.Now && firm.FirmYeniLogoBakimBitisTarihi < DateTime.Now && model.TicketState.ToUpper() == "07D17E00-B999-4A39-8C01-4E0CEB1925FD":
                //        return Response.Fail(400, "Firma Bakım Anlaşması Süresi Dolmuş, Ücretsiz Kapatamazsınız.", "Firma Bakım Anlaşması Süresi Dolmuş, Ücretsiz Kapatamazsınız.", true);
                //    // Departman Yazılım Geliştirme İse
                //    case "787E2B4E-89E6-41C1-AB0D-119F38C6E65D":
                //        //TODO : Logo CRM de açılınca Kullanılacak
                //        break;
                //}
                #endregion

                if (support == null)
                {
                    return Response.Fail(404, "Güncellenmek İstenilen Destek Kaydı Bilgilerine Ulaşılamadı",
                        $"{model.Oid} kimlik bilgisine sahip destek kaydı veri tabanında bulunamadı", true);
                }

                #region Destek Kaydı Güncelleme İşlemi
                support._LastModifiedDateTime = DateTime.Now;
                support._LastModifiedBy = new Guid(model._LastModifiedBy);
                support.Notlar = model.Notlar;
                support.TicketState = supportState!.Oid;
                support.TicketType = supportType!.Oid;
                if (supportState!.IsCompleted == true)
                {

                    switch (supportState.Oid.ToString().ToUpper())
                    {

                        case "BD6344E9-E338-47A3-B6C0-38D9385B80B4"://Ücretli Kapandı
                            if (!string.IsNullOrEmpty(model.TicketStartDate))
                            {
                                var sDate = DateTime.ParseExact(model.TicketStartDate, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                                support.TicketStartDate = sDate;
                            }
                            else
                            {
                                support.TicketStartDate = DateTime.Now;
                            }
                            if (!string.IsNullOrEmpty(model.TicketCompletedDate))
                            {
                                var eDate = DateTime.ParseExact(model.TicketCompletedDate, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                                support.TicketEstEndDate = eDate;
                                support.TicketCompletedDate = eDate;
                            }
                            else
                            {
                                support.TicketEstEndDate = DateTime.Now;
                                support.TicketCompletedDate = DateTime.Now;
                            }
                            support.IsCompleted = true;
                            support.TicketYapilanIslem = model.TicketYapilanIslem;
                            support.TicketUcret = model.TicketUcret;
                            support.CurrencyType = model.CurrencyType;
                            break;
                        case "07D17E00-B999-4A39-8C01-4E0CEB1925FD"://Tamamlandı
                            if (!string.IsNullOrEmpty(model.TicketStartDate))
                            {
                                var sDate = DateTime.ParseExact(model.TicketStartDate, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                                support.TicketStartDate = sDate;
                            }
                            else
                            {
                                support.TicketStartDate = DateTime.Now;
                            }
                            if (!string.IsNullOrEmpty(model.TicketCompletedDate))
                            {
                                var eDate = DateTime.ParseExact(model.TicketCompletedDate, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                                support.TicketEstEndDate = eDate;
                                support.TicketCompletedDate = eDate;
                            }
                            else
                            {
                                support.TicketEstEndDate = DateTime.Now;
                                support.TicketCompletedDate = DateTime.Now;
                            }
                            support.TicketYapilanIslem = model.TicketYapilanIslem;
                            support.IsCompleted = true;
                            break;

                    }
                }
                else
                {
                    if (supportState.Oid.ToString().ToUpper() == "439E8FB4-B576-4650-83DE-656EE3CFD3E7")
                    {
                        support.JiraOrSupportCode = model.JiraOrSupportCode;
                        support.Version = model.Version;
                        if (!string.IsNullOrEmpty(model.RegisterDate))
                        {
                            var rDate = DateTime.ParseExact(model.RegisterDate, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                            support.RegisterDate = rDate;
                        }
                        else
                        {
                            support.RegisterDate = DateTime.Now;
                        }

                    }
                }

                _repository.UpdateTicket(support);
                #endregion

                return Response.Success(200, $"{firm.FirmTitle} Firmasının {support.TicketId} Numaralı Destek Kaydı Durumu \"{supportState.TicketStateDescription}\" Olarak Başarıyla Güncellendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Destek Kaydı Güncellenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
        public string GetNextTicketId()
        {
            var res = _crmSqlService.GetCrmSupportNextId();
            return res.Data;
        }
        public async Task<Response<List<CrmFirmOpenSupportViewModel>>> GetFirmOpenSupports(string firmOid, List<Guid> Statuses)
        {
            try
            {
                var firmGuid = new Guid(firmOid);
                var supports = await _repository.Where(x => x.TicketFirm == firmGuid).ToListAsync();
                supports = supports.Where(x => Statuses.Any(y => y == x.TicketState)).ToList();

                var retVal = _mapper.Map<List<CrmFirmOpenSupportViewModel>>(supports);
                return Response<List<CrmFirmOpenSupportViewModel>>.SuccessData(200,
                    "Firma Açık Destek Kayıtları Başarıyla Alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<CrmFirmOpenSupportViewModel>>.FailData(400, "Filtrelenmiş Destek Kayıtları Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
        public async Task<Response<List<CrmFirmOpenSupportViewModel>>> GetFirmSupports(string firmOid)
        {
            try
            {
                var firmGuid = new Guid(firmOid);
                var userGuid = new Guid("A0EFF398-D31A-4767-A1DE-445312C9E086");//Webuser

                var supports = await _repository
                    .Where(x => x.TicketFirm == firmGuid &&
                                x._CreatedDateTime > new DateTime(2022, 1, 1) &&
                                x.AssignedTo == userGuid)
                    .ToListAsync();

                var retVal = _mapper.Map<List<CrmFirmOpenSupportViewModel>>(supports);
                return Response<List<CrmFirmOpenSupportViewModel>>.SuccessData(200,
                    "Firma Açık Destek Kayıtları Başarıyla Alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<CrmFirmOpenSupportViewModel>>.FailData(400, "Filtrelenmiş Destek Kayıtları Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
    }
}
