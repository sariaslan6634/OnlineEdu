using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Validators
{
    public class CustomErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Description = "şifre en az 1 rakam içermelidir."
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Description = "Şifre en az 1 kücük harf içermelidir."
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir özel karekter içermelidir [, . - _ * gibi]"
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Description = $"Şifare en az {length} karekter içermelidir."
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir büyük harf (A-Z) içermelidir."
            };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Description = $"{userName} kullanıcı adıyla bir kayıt var."
            };
        }
    }

}
