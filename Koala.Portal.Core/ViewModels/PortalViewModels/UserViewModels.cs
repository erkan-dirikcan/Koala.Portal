using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{


    public class CreateUserViewModel
    {
        public CreateUserViewModel()
        {
        }
        public CreateUserViewModel(string name, string lastname, string title, string password, string email, string phoneNumber, string? oid)
        {
            Name = name;
            Lastname = lastname;
            Title = title;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            Oid = oid;
        }
        [Required(ErrorMessage = "İlişkili CRM Kullanıcısı Seçilmemiş")]
        [Display(Name = "CRM Kullanıcısı")]
        public string? Oid { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad Alanı Boş Bırakılamaz")]
        public string? Name { get; set; }
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad Alanı Boş Bırakılamaz")]

        public string? Lastname { get; set; }
        [Display(Name = "Ünvan")]
        [Required(ErrorMessage = "Ünvan Alanı Boş Bırakılamaz")]

        public string? Title { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Boş Bırakılamaz")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "E-Posta Alanı Boş Bırakılamaz")]
        [Display(Name = "E-Posta")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Telefon Alanı Boş Bırakılamaz")]
        [Display(Name = "Telefon")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "GetPass Kullanıcısı")]
        public string? SKey { get; set; }

    }
    public class UpdateUserVievModel
    {
        public UpdateUserVievModel()
        {

        }
        public UpdateUserVievModel(string id, string name, string lastname, string title, string email, string? oid, string? sKey)
        {
            Id = id;
            Name = name;
            Lastname = lastname;
            Title = title;
            Email = email;
            Oid = oid;
            SKey = sKey;
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "İlişkili CRM Kullanıcısı Seçilmemiş")]
        [Display(Name = "CRM Kullanıcısı")]
        public string? Oid { get; set; }
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad Alanı Boş Bırakılamaz")]
        public string? Name { get; set; }
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad Alanı Boş Bırakılamaz")]

        public string? Lastname { get; set; }
        [Display(Name = "Ünvan")]
        [Required(ErrorMessage = "Ünvan Alanı Boş Bırakılamaz")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "E-Posta Alanı Boş Bırakılamaz")]
        [Display(Name = "E-Posta")]
        [EmailAddress]
        public string? Email { get; set; }
        [Display(Name = "GetPass Kullanıcısı")]
        public string? SKey { get; set; }

    }
    public class UserListViewModel
    {
        public string? Id { get; set; }
        [Display(Name = "Ad Soyad")]
        public string? Fullname { get; set; }
        [Display(Name = "Ünvan")]
        public string? Title { get; set; }
        [Display(Name = "E-Posta")]
        public string? Email { get; set; }
        [Display(Name = "Telefon")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Durum")]
        public int Status { get; set; }
    }
    public class UserInfoViewModel
    {
        public string? Id { get; set; }
        public string? Oid { get; set; }
        [Display(Name = "Ad")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Soyad")]
        [Required]
        public string Lastname { get; set; }
        [Display(Name = "Ad Soyad")]
        public string? Fullname { get; set; }
        [Display(Name = "Ünvan")]
        public string? Title { get; set; }
        [Display(Name = "E-Posta")]
        public string? Email { get; set; }
        [Display(Name = "Telefon")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Durum")]
        public int Status { get; set; }
    }
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-Posta Alanı Boş Bırakılamaz")]
        [Display(Name = "E-Posta")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Boş Bırakılamaz")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
    public class ResetPasswordViewModel
    {
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifre ve Şifre Onay Eşleşmiyor")]
        [Display(Name = "Şifre Onay")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

    }
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "E-Posta Alanı Boş Bırakılamaz")]
        [Display(Name = "E-Posta")]
        [EmailAddress]
        public string? Email { get; set; }



    }
    public class UserProfilInfoViewModel
    {
        [Display(Name = "Ad")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Soyad")]
        [Required]
        public string Lastname { get; set; }
        [Display(Name = "Ünvan")]

        public string? Title { get; set; }
        [Display(Name = "E-Posta")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "İki Aşamalı Güvenlik")]
        public bool TwoFactorEnebled { get; set; }
        [Display(Name = "Doğum Günü")]
        public string? BirthDate { get; set; }
        [Display(Name = "Profil Resmi")]
        public IFormFile? Avatar { get; set; }
    }
    public class ChangePasswordViewModel
    {
        [Display(Name = "Eski Şifre")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifre ve Şifre Onay Eşleşmiyor")]
        [Display(Name = "Yeni Şifre Onay")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
    public class UserSummaryViewModel
    {
        public string? Oid { get; set; }
        public string? Caption { get; set; }
        public string? EMailAddress { get; set; }
        public string? Avatar { get; set; }
        public bool? IsActive { get; set; }
    }
    public class AddVacationViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required(ErrorMessage ="izin Miktarı Girilmesi Zorunludur")]
        public string Amount { get; set; }
        [MinLength(10,ErrorMessage ="En az 10 Karakter Girilmelidir.")]
        [Required(ErrorMessage ="Açıklama Girilmesi Zorunludur")]
        public string Description { get; set; }
    }

}
