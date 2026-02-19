using System.ComponentModel.DataAnnotations;

namespace Koala.Portal.WebUI.Models.ViewModels
{


    public class CreateUserViewModel
    {
        public CreateUserViewModel()
        {

        }
        public CreateUserViewModel(string name, string lastname, string title, string password, string email, string phoneNumber)
        {
            Name = name;
            Lastname = lastname;
            Title = title;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad Alanı Boş Bırakılamaz")]
        public string Name { get; set; }
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad Alanı Boş Bırakılamaz")]

        public string Lastname { get; set; }
        [Display(Name = "Ünvan")]
        [Required(ErrorMessage = "Ünvan Alanı Boş Bırakılamaz")]

        public string Title { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Boş Bırakılamaz")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "E-Posta Alanı Boş Bırakılamaz")]
        [Display(Name = "E-Posta")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon Alanı Boş Bırakılamaz")]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }


    }

    public class UserListViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Ad Soyad")]
        public string Fullname { get; set; }
        [Display(Name = "Ünvan")]
        public string Title { get; set; }
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }
               [Display(Name = "Durum")]
        public int Status { get; set; }
    }
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-Posta Alanı Boş Bırakılamaz")]
        [Display(Name = "E-Posta")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Boş Bırakılamaz")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
    public class ResetPasswordViewModel
    {

    }
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "E-Posta Alanı Boş Bırakılamaz")]
        [Display(Name = "E-Posta")]
        [EmailAddress]
        public string Email { get; set; }
       

        
    }
}
