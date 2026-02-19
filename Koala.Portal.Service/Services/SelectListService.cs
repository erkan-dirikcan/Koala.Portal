using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Service.Services
{

    public class SelectListService(
        IAgendaTypeRepository agendaTypeService,
        IFixtureRepository fixtureRepository,
        IFirmRepository firmRepository,
        IFirmContactRepository firmContactRepository,
        IHelpDeskCategoryRepository helpDeskCategoryRepository,
        IHelpDeskProblemRepository helpDeskProblemRepository,
        IModuleRepository moduleRepository,
        IUserRepository userRepository)
        : ISelectListService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public Task<Response<List<SelectListItem>>> GetAgendaTypeSelectList(string selected = "")
        {
            try
            {
                var res = agendaTypeService.Where(x => x.IsActive == true && x.Id == selected);

                var items = new List<SelectListItem>();
                foreach (var item in res)
                {
                    var model = new SelectListItem
                    {
                        Text = $"({item.Name}) - {item.Description}",
                        Value = item.Id,
                        Selected = String.Equals(selected, item.Id, StringComparison.CurrentCultureIgnoreCase)
                    };
                    items.Add(model);
                }

                return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Etkinlik Tipi Listesi Başarıyla Alındı", items));
            }
            catch (Exception ex)
            {
                return Task.FromResult<Response<List<SelectListItem>>>(Response<List<SelectListItem>>.FailData(400,
                    "Etkinlik tipi listesi alınırken bir sorunla karşılaşıldı", ex.Message, false));
            }
        }

        public Task<Response<List<SelectListItem>>> GetFixtureSelectList(string selected = "")
        {
            try
            {
                var res = fixtureRepository.Where(x => x.IsActive == true && x.Id == selected);

                var items = new List<SelectListItem>();
                foreach (var item in res)
                {
                    var model = new SelectListItem
                    {
                        Text = $"({item.Name}) - {item.Description}",
                        Value = item.Id,
                        Selected = String.Equals(selected, item.Id, StringComparison.CurrentCultureIgnoreCase)
                    };
                    items.Add(model);
                }

                return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Demirbaş Listesi Başarıyla Alındı", items));
            }
            catch (Exception ex)
            {
                return Task.FromResult<Response<List<SelectListItem>>>(Response<List<SelectListItem>>.FailData(400,
                    "Demirbaş listesi alınırken bir sorunla karşılaşıldı", ex.Message, false));
            }
        }

        public async Task<Response<List<SelectListItem>>> GetFirmSelectList(string selected = "")
        {
            try
            {
                var res = await firmRepository.Where(x => x.InUse == true).ToListAsync();

                var items = res.Select(item => new SelectListItem
                {
                    Text = $"({item.Code}) - {item.Title}",
                    Value = item.Id,
                    Selected = string.Equals(selected, item.Id, StringComparison.CurrentCultureIgnoreCase)
                }).ToList();

                return Response<List<SelectListItem>>.SuccessData(200, "Firma Listesi Başarıyla Alındı", items);
            }
            catch (Exception ex)
            {
                return Response<List<SelectListItem>>.FailData(400,
                    "Firma listesi alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<List<SelectListItem>>> GetFirmContactSelectList(string firmId, string selected = "")
        {
            try
            {
                var res = await firmContactRepository.GetAllAsync(firmId);
                var retVal = new List<SelectListItem>();
                foreach (var item in res)
                {
                    retVal.Add(new SelectListItem
                    {
                        Text = $"{item.Name} {item.LastName}",
                        Value = item.Id,
                        Selected = string.Equals(item.Id, selected, StringComparison.OrdinalIgnoreCase)
                    });
                }
                return Response<List<SelectListItem>>.SuccessData(200, "Firma Yetkili Listesi Başarıyla Alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<SelectListItem>>.FailData(400, "Firma Yetkili Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<List<SelectListItem>>> GetUserSelectList(string selected = "")
        {
            try
            {
                var res = await userRepository.GetUsers();

                var items = res.Select(item => new SelectListItem
                {
                    Text = $"{item.Name} {item.Lastname} - ({item.Email})",
                    Value = item.Id,
                    Selected = string.Equals(selected, item.Id, StringComparison.CurrentCultureIgnoreCase)
                }).ToList();
                return Response<List<SelectListItem>>.SuccessData(200, "Kullanıcı Listesi Başarıyla Alındı", items);
            }
            catch (Exception ex)
            {

                return Response<List<SelectListItem>>.FailData(400,
                    "Kullanıcı listesi alınırken bir sorunla karşılaşıldı", ex.Message, false); ;
            }
        }

        public Task<Response<List<SelectListItem>>> GetCategorySelectList(string selected = "")
        {
            try
            {
                var res = helpDeskCategoryRepository.Where(x => x.Status == StatusEnum.Active).ToList();

                var items = new List<SelectListItem>();
                foreach (var item in res)
                {
                    var model = new SelectListItem
                    {
                        Text = $"({item.Name}) - {item.Description}",
                        Selected = String.Equals(selected, item.Id, StringComparison.CurrentCultureIgnoreCase),
                        Value = item.Id
                    };
                    items.Add(model);
                }
                return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Yardım Masası Kategori Listesi Başarıyla Alındı", items));
            }
            catch (Exception ex)
            {
                return Task.FromResult<Response<List<SelectListItem>>>(Response<List<SelectListItem>>.FailData(400,
                   "Yardım Masası Kategorileri alınırken bir sorunla karşılaşıldı", ex.Message, false));
            }
        }

        public Task<Response<List<SelectListItem>>> GetProblemSelectList(string selected = "")
        {
            try
            {
                var res = helpDeskProblemRepository.Where(x => x.Status == StatusEnum.Active).ToList();

                var items = new List<SelectListItem>();
                foreach (var item in res)
                {
                    var model = new SelectListItem
                    {
                        Text = $"{item.Title}",
                        Selected = String.Equals(selected, item.Id, StringComparison.CurrentCultureIgnoreCase),
                        Value = item.Id
                    };
                    items.Add(model);
                }
                return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Yardım Masası Çözüm Listesi Başarıyla Alındı", items));
            }
            catch (Exception ex)
            {
                return Task.FromResult<Response<List<SelectListItem>>>(Response<List<SelectListItem>>.FailData(400,
                   "Yardım Masası Çözümü alınırken bir sorunla karşılaşıldı", ex.Message, false));
            }
        }

        public Task<Response<List<SelectListItem>>> GetModuleSelectList(string selected = "")
        {
            try
            {
                var res = moduleRepository.Where(x => x.Status == StatusEnum.Active).ToList();

                var items = new List<SelectListItem>();
                foreach (var item in res)
                {
                    var model = new SelectListItem
                    {
                        Text = $"{item.DisplayName}",
                        Selected = String.Equals(selected, item.Id, StringComparison.CurrentCultureIgnoreCase),
                        Value = item.Id
                    };
                    items.Add(model);
                }
                return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Modül Listesi Başarıyla Alındı", items));
            }
            catch (Exception ex)
            {
                return Task.FromResult<Response<List<SelectListItem>>>(Response<List<SelectListItem>>.FailData(400, "Modül Bilgileri Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false));
            }
        }

        //public Response<List<SelectListItem>> GetPriorityEnumSelectList(PriorityEnum selected)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
