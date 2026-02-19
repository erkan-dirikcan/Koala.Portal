using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.Helpers
{
    public static class SelectListHelpers
    {
        public static List<SelectListDto<StatusEnum>> GetStatusSelectList(StatusEnum? selected)
        {
            return new List<SelectListDto<StatusEnum>>
            {
                new SelectListDto<StatusEnum>() { Key = "Aktif", Val = StatusEnum.Active, IsSelected = selected == StatusEnum.Active },
                new SelectListDto<StatusEnum>() { Key = "Pasif", Val = StatusEnum.Pasive, IsSelected = selected == StatusEnum.Pasive }
            };
        }

        public static List<SelectListDto<ConnectionTypeEnum>> GetConnectionTypeSelectList(ConnectionTypeEnum? selected)
        {
            return new List<SelectListDto<ConnectionTypeEnum>>
            {
                new SelectListDto<ConnectionTypeEnum> { Key = "Sql Server", Val = ConnectionTypeEnum.SqlServer, IsSelected = selected == ConnectionTypeEnum.SqlServer },
                new SelectListDto<ConnectionTypeEnum> { Key = "Sql Server", Val = ConnectionTypeEnum.SqlServer, IsSelected = selected == ConnectionTypeEnum.SqlServer },
                new SelectListDto<ConnectionTypeEnum> { Key = "Uzak Masaüstü", Val = ConnectionTypeEnum.RemoteDesktop, IsSelected = selected == ConnectionTypeEnum.RemoteDesktop},
                new SelectListDto<ConnectionTypeEnum> { Key = "Logo Tiger", Val =ConnectionTypeEnum.LogoTiger, IsSelected = selected == ConnectionTypeEnum.LogoTiger },
                new SelectListDto<ConnectionTypeEnum> { Key = "Logo Go", Val = ConnectionTypeEnum.LogoGo, IsSelected = selected == ConnectionTypeEnum.LogoGo },
                new SelectListDto<ConnectionTypeEnum> { Key = "Logo Rest Servis", Val = ConnectionTypeEnum.LogoRestService, IsSelected = selected == ConnectionTypeEnum.LogoRestService },
                new SelectListDto<ConnectionTypeEnum> { Key = "Vpn", Val = ConnectionTypeEnum.Vpn, IsSelected = selected == ConnectionTypeEnum.Vpn }
            };
        }
        public static List<SelectListDto<CurrencyTypeEnum>> GetCurrencyList(CurrencyTypeEnum? selected)
        {
            return new List<SelectListDto<CurrencyTypeEnum>>
            {
                new SelectListDto<CurrencyTypeEnum>() {IsSelected = selected == CurrencyTypeEnum.Us, Key = "Dolar", Val = CurrencyTypeEnum.Us},
                new SelectListDto<CurrencyTypeEnum>() {IsSelected = selected == CurrencyTypeEnum.Eu, Key = "Euro", Val = CurrencyTypeEnum.Eu},
                new SelectListDto<CurrencyTypeEnum>() {IsSelected = selected == CurrencyTypeEnum.Tl, Key = "Türk Lirası", Val = CurrencyTypeEnum.Tl}
            };
        }

        public static List<SelectListDto<RoleTypeEnum>> GetRoleTypeList(RoleTypeEnum? selected)
        {
            return new List<SelectListDto<RoleTypeEnum>>
            {
                new SelectListDto<RoleTypeEnum> {IsSelected = selected == RoleTypeEnum.Admin, Key = "Yönetici", Val = RoleTypeEnum.Admin},
                new SelectListDto<RoleTypeEnum> {IsSelected = selected == RoleTypeEnum.Client, Key = "Alıcı Uygulama", Val = RoleTypeEnum.Client},
                new SelectListDto<RoleTypeEnum> {IsSelected = selected == RoleTypeEnum.Customer, Key = "Kullanıcı", Val = RoleTypeEnum.Customer}
            };
        }

        public static List<SelectListDto<PhoneTypeEnum>> GetPhoneTypeList(PhoneTypeEnum? selected)
        {
            return new List<SelectListDto<PhoneTypeEnum>>
            {
                new SelectListDto<PhoneTypeEnum> {IsSelected = selected == PhoneTypeEnum.LandPhone, Key ="Sabit Telefon" , Val = PhoneTypeEnum.LandPhone},
                new SelectListDto<PhoneTypeEnum> {IsSelected = selected == PhoneTypeEnum.Mobile, Key ="Cep Telefonu" , Val = PhoneTypeEnum.Mobile},
                new SelectListDto<PhoneTypeEnum> {IsSelected = selected == PhoneTypeEnum.Fax, Key ="Fax", Val = PhoneTypeEnum.Fax}
            };
        }

        public static List<SelectListDto<MessageStatusEnum>> GetMessageStatusList(MessageStatusEnum? selected)
        {
            return new List<SelectListDto<MessageStatusEnum>>
            {
                new SelectListDto<MessageStatusEnum> {IsSelected = selected == MessageStatusEnum.Deleted , Key ="Silindi" , Val = MessageStatusEnum.Deleted},
                new SelectListDto<MessageStatusEnum> {IsSelected = selected == MessageStatusEnum.Readed , Key ="Okundu" , Val = MessageStatusEnum.Readed},
                new SelectListDto<MessageStatusEnum> {IsSelected = selected == MessageStatusEnum.UnReaded , Key ="Okunamadı" , Val = MessageStatusEnum.UnReaded}
            };
        }
        public static List<SelectListDto<ToDoFrequencyEnum>> GetToDoFrequencyList(ToDoFrequencyEnum? selected)
        {
            return new List<SelectListDto<ToDoFrequencyEnum>>
                {
                    new SelectListDto<ToDoFrequencyEnum> {IsSelected = selected == ToDoFrequencyEnum.Day , Key ="Gün" , Val = ToDoFrequencyEnum.Day},
                    new SelectListDto<ToDoFrequencyEnum> {IsSelected = selected == ToDoFrequencyEnum.Hour , Key ="Saat" , Val = ToDoFrequencyEnum.Hour},
                    new SelectListDto<ToDoFrequencyEnum> {IsSelected = selected == ToDoFrequencyEnum.JustOne , Key ="Sadece Bir Kez" , Val = ToDoFrequencyEnum.JustOne},
                    new SelectListDto<ToDoFrequencyEnum> {IsSelected = selected == ToDoFrequencyEnum.Month , Key ="Ay" , Val = ToDoFrequencyEnum.Month},
                    new SelectListDto<ToDoFrequencyEnum> {IsSelected = selected == ToDoFrequencyEnum.Quarter , Key ="3 Aylık" , Val = ToDoFrequencyEnum.Quarter},
                    new SelectListDto<ToDoFrequencyEnum> {IsSelected = selected == ToDoFrequencyEnum.Week , Key ="Haftalık" , Val = ToDoFrequencyEnum.Week },
                };
            }
        public static List<SelectListDto<PriorityEnum>> GetPriorityEnumList(PriorityEnum? selected)
        {
            return new List<SelectListDto<PriorityEnum>>
            {
                new SelectListDto<PriorityEnum> {IsSelected = selected == PriorityEnum.High , Key ="Yüksek" , Val = PriorityEnum.High},
                new SelectListDto<PriorityEnum> {IsSelected = selected == PriorityEnum.Low , Key ="Düşük" , Val = PriorityEnum.Low},
                new SelectListDto<PriorityEnum> {IsSelected = selected == PriorityEnum.Normal , Key ="Normal"},
            };
        }
        public static List<SelectListDto<UserStatusEnum>> GetUserStatusList(UserStatusEnum? selected)
        {
            return new List<SelectListDto<UserStatusEnum>>
            {
                new SelectListDto<UserStatusEnum> {IsSelected = selected == UserStatusEnum.Active , Key ="Aktif" , Val = UserStatusEnum.Active},
                new SelectListDto<UserStatusEnum> {IsSelected = selected == UserStatusEnum.Passive , Key="Pasif" , Val = UserStatusEnum.Passive},
                new SelectListDto<UserStatusEnum> {IsSelected = selected == UserStatusEnum.Blocked , Key ="Engellendi" , Val = UserStatusEnum.Blocked}
            };
        }
        public static List<SelectListDto<PurchasingStatusEnum>> GetPurchasingStatusList(PurchasingStatusEnum? selected)
        {
            return new List<SelectListDto<PurchasingStatusEnum>>
            {
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.Canceled , Key ="İptal Edildi" , Val = PurchasingStatusEnum.Canceled},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.Closed , Key ="Kapatıldı" , Val = PurchasingStatusEnum.Closed},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.CollectedOffers , Key ="Teklifler Toplandı" , Val = PurchasingStatusEnum.CollectedOffers},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.CollectingOffers , Key ="Teklifler Toplanıyor" , Val = PurchasingStatusEnum.CollectingOffers},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.Created , Key ="Oluşturuldu" , Val = PurchasingStatusEnum.Created},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.Deleted , Key ="Silindi" , Val = PurchasingStatusEnum.Deleted},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.InCargo , Key ="Kargolandı" , Val = PurchasingStatusEnum.InCargo},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.ManagementCheck , Key ="Yönetim Onayında" , Val = PurchasingStatusEnum.ManagementCheck},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.ManagementCheckCanceled , Key ="Yönetim Onayında Vazgeçildi" , Val = PurchasingStatusEnum.ManagementCheckCanceled},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.MissingMaterial , Key ="Eksik Malzeme" , Val = PurchasingStatusEnum.MissingMaterial},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.Ordered , Key ="Sipariş Verildi" , Val = PurchasingStatusEnum.Ordered},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.PendingRevision , Key ="Revizyon Bekliyor" , Val = PurchasingStatusEnum.PendingRevision},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.ProjectManagerCheck , Key ="Proje Yöneticisi Onayında" , Val = PurchasingStatusEnum.ProjectManagerCheck},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.ProjectManagerCheckCanceled , Key ="Proje Yöneticisi Onayında Vazgeçildi" , Val = PurchasingStatusEnum.ProjectManagerCheckCanceled},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.PurchaseConfirmation , Key ="Satın Alma Onayında" , Val = PurchasingStatusEnum.PurchaseConfirmation},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.PurchaseConfirmationCanceled , Key="Satın Alma Onayında Vazgeçildi" , Val = PurchasingStatusEnum.PurchaseConfirmationCanceled},
                new SelectListDto<PurchasingStatusEnum> {IsSelected = selected == PurchasingStatusEnum.Revised , Key ="Revize" , Val = PurchasingStatusEnum.Revised}
                };
        }
        public static List<SelectListDto<PurchasingItemStatusEnum>> GetPurchasingItemStatusList(PurchasingItemStatusEnum? selected)
        {
            return new List<SelectListDto<PurchasingItemStatusEnum>>
            {
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.Approved , Key ="Onaylandı" , Val = PurchasingItemStatusEnum.Approved},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.Canceled , Key ="İptal Edildi" , Val = PurchasingItemStatusEnum.Canceled},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.Closed , Key ="Kapatıldı" , Val = PurchasingItemStatusEnum.Closed},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.CollectedOffers , Key ="Teklifler Toplandı" , Val = PurchasingItemStatusEnum.CollectedOffers},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.CollectingOffers , Key ="Teklifler Toplaniyor" , Val = PurchasingItemStatusEnum.CollectingOffers},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.Deleted , Key ="Silindi" , Val = PurchasingItemStatusEnum.Deleted},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.InCargo , Key ="Kargolandı" , Val = PurchasingItemStatusEnum.InCargo},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.ManagementCheck , Key ="Yönetim Onayında" , Val = PurchasingItemStatusEnum.ManagementCheck},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.ManagementCheckCanceled , Key ="Yönetim Onayında Vazgeçildi" , Val = PurchasingItemStatusEnum.ManagementCheckCanceled},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.Ordered , Key ="Sipariş Verildi" , Val = PurchasingItemStatusEnum.Ordered},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.PendingRevision , Key ="Revizyon Bekliyor" , Val = PurchasingItemStatusEnum.PendingRevision},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.ProjectManagerCheck , Key ="Proje Yöneticisi Onayunda" , Val = PurchasingItemStatusEnum.ProjectManagerCheck},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.ProjectManagerCheckCanceled , Key = "Proje Yöneticisi Onayında Vazgeçildi" , Val = PurchasingItemStatusEnum.ProjectManagerCheckCanceled},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.PurchaseConfirmation , Key ="Satın Alma Onayında" , Val = PurchasingItemStatusEnum.PurchaseConfirmation},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.PurchaseConfirmationCanceled , Key ="Satın Alma Onayında Vazgeçildi" , Val = PurchasingItemStatusEnum.PurchaseConfirmationCanceled},
                new SelectListDto<PurchasingItemStatusEnum> {IsSelected = selected == PurchasingItemStatusEnum.Revised , Key ="Revize" , Val = PurchasingItemStatusEnum.Revised}
            };
        }
        public static List<SelectListDto<PurchasingTypesEnum>> GetPurchasingTypesList(PurchasingTypesEnum? selected)
        {
            return new List<SelectListDto<PurchasingTypesEnum>>
            {
                new SelectListDto<PurchasingTypesEnum> {IsSelected = selected == PurchasingTypesEnum.ConstructionGroup , Key="İnşaat Grubu" , Val = PurchasingTypesEnum.ConstructionGroup},
                new SelectListDto<PurchasingTypesEnum> {IsSelected = selected == PurchasingTypesEnum.ElectricalorMechanical , Key="Elektrik veya Mekanik" , Val = PurchasingTypesEnum.ElectricalorMechanical}
            };
        }

        public static List<SelectListDto<PurchasingOrderStatusEnum>> GetPurchasingOrderStatusList(PurchasingOrderStatusEnum? selected)
        {
            return new List<SelectListDto<PurchasingOrderStatusEnum>>
            {
                new SelectListDto<PurchasingOrderStatusEnum> {IsSelected = selected == PurchasingOrderStatusEnum.Canceled , Key ="İptal Edildi" , Val = PurchasingOrderStatusEnum.Canceled},
                new SelectListDto<PurchasingOrderStatusEnum> {IsSelected = selected == PurchasingOrderStatusEnum.GettingReady , Key ="Hazırlanıyor" , Val = PurchasingOrderStatusEnum.GettingReady},
                new SelectListDto<PurchasingOrderStatusEnum> {IsSelected = selected == PurchasingOrderStatusEnum.Incorrect , Key="Hatalı" , Val = PurchasingOrderStatusEnum.Incorrect},
                new SelectListDto<PurchasingOrderStatusEnum> {IsSelected = selected == PurchasingOrderStatusEnum.Missing , Key ="Eksik" , Val = PurchasingOrderStatusEnum.Missing},
                new SelectListDto<PurchasingOrderStatusEnum> {IsSelected = selected == PurchasingOrderStatusEnum.OnShipment , Key ="Sevkiyatta" , Val = PurchasingOrderStatusEnum.OnShipment},
                new SelectListDto<PurchasingOrderStatusEnum> {IsSelected = selected == PurchasingOrderStatusEnum.SentToSeller , Key = "Satıcıya Gönderildi" , Val = PurchasingOrderStatusEnum.SentToSeller},
                new SelectListDto<PurchasingOrderStatusEnum> {IsSelected = selected == PurchasingOrderStatusEnum.Viewed , Key ="Görüntülendi" , Val = PurchasingOrderStatusEnum.Viewed}
            };
        }

        public static List<SelectListDto<FinancelRequestStatusEnum>> GetFinancelRequestStatusList(FinancelRequestStatusEnum? selected)
        {
            return new List<SelectListDto<FinancelRequestStatusEnum>>

            {
                new SelectListDto<FinancelRequestStatusEnum> {IsSelected = selected == FinancelRequestStatusEnum.Approved , Key = "Onaylandı" , Val = FinancelRequestStatusEnum.Approved},
                new SelectListDto<FinancelRequestStatusEnum> {IsSelected = selected == FinancelRequestStatusEnum.AwaitingApproval , Key ="Onay Bekleniyor" , Val = FinancelRequestStatusEnum.AwaitingApproval},
                new SelectListDto<FinancelRequestStatusEnum> {IsSelected = selected == FinancelRequestStatusEnum.AwaitingRevision , Key ="Revizyon Bekleniyor" , Val = FinancelRequestStatusEnum.AwaitingRevision},
                new SelectListDto<FinancelRequestStatusEnum> {IsSelected = selected == FinancelRequestStatusEnum.Rejected , Key = "Reddedildi" , Val = FinancelRequestStatusEnum.Rejected}
            };
        }
        //public static List<SelectListDto<PaymentTypeEnum>> GetPaymentTypeList(PaymentTypeEnum? selected)
        //{
        //    return new List<SelectListDto<PaymentTypeEnum>>
        //    {
        //        new() {IsSelected = selected == PaymentTypeEnum.Cash , Key ="Nakit" , Val = PaymentTypeEnum.Cash},
        //        new() {IsSelected = selected == PaymentTypeEnum.CreditCard , Key = "Kredi Kartı" , Val = PaymentTypeEnum.CreditCard},
        //        new() {IsSelected = selected == PaymentTypeEnum.Check , Key ="", Val = PaymentTypeEnum.Check},
        //        new() {IsSelected = selected == PaymentTypeEnum.Note , Key="" , Val = PaymentTypeEnum.Note}
        //    };

        //}
    }
}
