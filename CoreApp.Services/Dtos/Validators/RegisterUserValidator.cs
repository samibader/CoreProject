using FluentValidation;
using FluentValidation.Results;
using CoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreApp.Services.Dtos.Validators.PropertyValidators;

namespace CoreApp.Services.Dtos.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public readonly IUserService _userService;
        //public RegisterUserValidator()
        public RegisterUserValidator(IUserService userService)
        {
            _userService = userService;
            RuleSet("Register", () =>
            {
                //RegisterRules();
                CommonRules();
            });
            //CommonRules();
        }

        public void CommonRules()
        {
            RuleFor(m => m.Email).NotEmpty().WithMessage("البريد الالكتروني مطلوب").Length(1, 256).WithMessage("البريد الالكتروني مرفوض").EmailAddress().WithMessage("بريد الكتروني غير صحيح");
            RuleFor(m => m.Password).NotEmpty().WithMessage("كلمة المرور مطلوبة").Length(3, 25).WithMessage("كلمة المرور مرفوضة");
            RuleFor(m => m.ConfirmPassword).NotEmpty().WithMessage("تأكيد كلمة المرور مطلوبة").Equal(x => x.Password).WithMessage("كلمة المرور وتأكيدها غير متطابقان");
            RuleFor(m => m.FullName).NotEmpty().WithMessage("الاسم مطلوب");
            //Custom(m =>
            //{
            //    return !_userService.IsEmailUnique(m.Email)
            //       ? new ValidationFailure("Email", "البريد الالكتروني غير متاح !")
            //       : null;
            //});
            RuleFor(m => m.Email).SetValidator(new IsEmailUniquePropertyValidator(_userService));
        }
    }
}
