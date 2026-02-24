namespace Koala.Portal.Core.Dtos
{
    public enum RoleTypeEnum
    {
        Admin = 0x01,
        Customer = 0x02,
        Client = 0x03
    }

    public enum PhoneTypeEnum
    {
        LandPhone,
        Mobile,
        Fax
    }

    public enum MessageStatusEnum
    {
        Readed = 0x01,
        UnReaded = 0x02,
        Deleted = 0x03
    }
    public enum StatusEnum
    {
        Active = 0x01,
        Pasive = 0x02,
        Deleted = 0x03,
        Expiration = 0x04
    }
    public enum VacationStatus
    {
        WaitingForApproval= 0x01,
        Approved=0x02,
        Rejected=0x03,
        Canceled=0x04,
        Complated=0x05,
        WaitingForRevision=0x06,
        Revised=0x07
    }
    public enum VacationType
    {
        PaidVacation = 0x01,
        FreeVacation = 0x02,
        AnnualVacation = 0x03,
        VacationWithSicknessReport = 0x04,
        VacationWithoutSicknessReport = 0x05,
        MaternityVacation=0x06,
        PublicHoliday=0x07
    }
    public enum ApplicationLicenceStatusEnum
    {
        AcceptWaiting = 0x01,
        Accepted = 0x02,
        Rejected = 0x03,
        Locked = 0x04
    }
    public enum ToDoFrequencyEnum
    {
        JustOne = 0x00,
        Day = 0x01,
        Week = 0x02,
        Month = 0x03,
        Year = 0x04,
        Quarter = 0x05,
        Hour = 0x06
    }
    public enum PriorityEnum
    {
        Lowest = 0x01,
        Low = 0x02,
        Normal = 0x03,
        High = 0x04,
        Highest = 0x05
    }

    public enum ConnectionTypeEnum
    {
        SqlServer = 0x01,
        RemoteDesktop = 0x02,
        LogoTiger = 0x03,
        LogoGo = 0x04,
        LogoRestService = 0x05,
        Vpn = 0x06
    }

    public enum UserStatusEnum
    {
        Active = 0x01,
        Passive = 0x02,
        Removed = 0x03,
        Blocked = 0x04
    }

    public enum PurchasingStatusEnum
    {
        /// <summary>
        /// Proje Yöneticisi Onay
        /// </summary>
        ProjectManagerCheck = 0x01,
        /// <summary>
        /// Proje TYöneticisi Red
        /// </summary>
        ProjectManagerCheckCanceled = 0x02,
        /// <summary>
        /// Satın Alma Onay
        /// </summary>
        PurchaseConfirmation = 0x03,
        /// <summary>
        /// SDatın Alma Red
        /// </summary>
        PurchaseConfirmationCanceled = 0x04,
        /// <summary>
        /// Yönetim Onay
        /// </summary>
        ManagementCheck = 0x05,
        /// <summary>
        /// Yönetim Red
        /// </summary>
        ManagementCheckCanceled = 0x06,
        /// <summary>
        /// Teklif Toplanıyor
        /// </summary>
        CollectingOffers = 0x07,
        /// <summary>
        /// Teklif Toplandı
        /// </summary>
        CollectedOffers = 0x08,
        /// <summary>
        /// Sipariş Verildi
        /// </summary>
        Ordered = 0x09,
        /// <summary>
        /// Kargoda
        /// </summary>
        InCargo = 0x0A,
        /// <summary>
        /// Revize Edildi
        /// </summary>
        Revised = 0x0B,
        /// <summary>
        /// Revizyon Bekliyor
        /// </summary>
        PendingRevision = 0x0C,
        /// <summary>
        /// İptal Edildi
        /// </summary>
        Canceled = 0x0D,
        /// <summary>
        /// Kapatıldı
        /// </summary>
        Closed = 0x0E,
        /// <summary>
        /// Hatalı veYA Eksik Malzeme
        /// </summary>
        MissingMaterial = 0x0F,
        /// <summary>
        /// Silindi
        /// </summary>
        Deleted = 0x10,
        /// <summary>
        /// Oluşturuldu
        /// </summary>
        Created = 0x11


    }
    public enum PurchasingItemStatusEnum
    {
        /// <summary>
        /// Proje Yöneticisi Onay
        /// </summary>
        ProjectManagerCheck = 0x01,
        /// <summary>
        /// Proje Yöneticisi Red
        /// </summary>
        ProjectManagerCheckCanceled = 0x02,
        /// <summary>
        /// Satın Alma Onayı
        /// </summary>
        PurchaseConfirmation = 0x03,
        /// <summary>
        /// Satın Alma Red
        /// </summary>
        PurchaseConfirmationCanceled = 0x04,
        /// <summary>
        /// Yönetim Onay
        /// </summary>
        ManagementCheck = 0x05,
        /// <summary>
        /// Yönetim Red
        /// </summary>
        ManagementCheckCanceled = 0x06,
        /// <summary>
        /// Teklif Toplanıyor
        /// </summary>
        CollectingOffers = 0x07,
        /// <summary>
        /// Teklif Toplandı
        /// </summary>
        CollectedOffers = 0x08,
        /// <summary>
        /// Sipariş Verildi
        /// </summary>
        Ordered = 0x09,
        /// <summary>
        /// Kargoda
        /// </summary>
        InCargo = 0x0A,
        /// <summary>
        /// Revize Edildi
        /// </summary>
        Revised = 0x0B,
        /// <summary>
        /// Revizyon Bekliyor
        /// </summary>
        PendingRevision = 0x0C,
        /// <summary>
        /// İptal Edildi
        /// </summary>
        Canceled = 0x0D,
        /// <summary>
        /// Onaylandı
        /// </summary>
        Approved = 0x0E,
        /// <summary>
        /// Kapandı
        /// </summary>
        Closed = 0x0F,
        /// <summary>
        /// Silindi
        /// </summary>
        Deleted = 0x10
    }

    public enum PurchasingTypesEnum
    {
        ElectricalorMechanical,
        ConstructionGroup
    }

    public enum PurchasingOrderStatusEnum
    {
        SentToSeller = 0x01,
        Viewed = 0x02,
        GettingReady = 0x03,
        OnShipment = 0x04,
        Canceled = 0x05,
        Missing = 0x06,
        Incorrect = 0x07

    }

    public enum CurrencyTypeEnum
    {
        Us = 0x01,
        Eu = 0x14,
        Tl = 0xA0
    }

    public enum PaymentTypeEnum
    {
        Check = 0x01,
        Note = 0x02,
        Cash = 0x03,
        CreditCard = 0x03
    }

    public enum FinancelRequestStatusEnum
    {
        AwaitingApproval = 0x01,
        Approved = 0x02,
        Rejected = 0x03,
        AwaitingRevision = 0x04,
    }

    public enum ProjectStatusEnum
    {
        Creating = 0x01,
        Created = 0x02,
        FirmInfoAdded = 0x03,
        StepsAdded = 0x04,
        Started = 0x05,
        Testing = 0x06,
        Finished = 0x07,
        Canceled = 0x08,
        Failed = 0x09
    }

    public enum ProjectLineStatusEnum
    {
        NotStarted = 0x01,
        InProgress = 0x02,
        WaitingForSomeoneElse = 0x03,
        Deferred = 0x04,
        Completed = 0x05,
        Cancellled = 0x06
    }
    public enum ProjectLineWorkStatusEnum
    {
        New=0x00,
        NotStarted = 0x01,
        InProgress = 0x02,
        WaitingForSomeoneElse = 0x03,
        Deferred = 0x04,
        Completed = 0x05,
        Canceled = 0x06,
        Reopened = 0x07
    }

    public enum FileAddedEnum
    {
        Contact = 0x01,
        User = 0x02
    }
    public enum AttachmentType
    {
        File = 0x01,
        VtranferLink = 0x02,
        GoogleDriveLink = 0x03
    }
}
