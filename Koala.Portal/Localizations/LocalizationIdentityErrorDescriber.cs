using Microsoft.AspNetCore.Identity;

namespace Koala.Portal.WebUI.Localizations
{
    public class LocalizationIdentityErrorDescriber:IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = "DuplicateEmail", Description = "Bu E-Posta Adresi Zaten Kullanılıyor"
            }; //base.DuplicateEmail(email);
        }
    }
}
