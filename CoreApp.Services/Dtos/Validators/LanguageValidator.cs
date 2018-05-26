using CoreApp.Domain;
using CoreApp.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Services.Dtos.Validators
{
    public class LanguageValidator : AbstractValidator<LanguageDto>
    {
        public readonly ILanguageService _languageService;
        
        public LanguageValidator(ILanguageService languageService, IUserService userService)
        {
            _languageService = languageService;
            RuleSet("Add", () =>
            {
                Custom(m =>
                {
                    return !_languageService.IsCodeUnique(m.Code,null)
                       ? new ValidationFailure("Code", " add كود اللغة موجود مسبقاً، يرجى إعادة الإدخال")
                       : null;
                });
                CommonRules();
            });
            RuleSet("Edit", () =>
            {
                RuleFor(m => m.Id)
                .NotEmpty()
                .WithMessage("Id should not be null");
                Custom(m =>
                {
                    return _languageService.GetById(m.Id) == null
                       ? new ValidationFailure("Id", "اللغة غير موجودة !")
                       : null;
                });
                Custom(m =>
                {
                    return !_languageService.IsCodeUnique(m.Code, m.Id)
                       ? new ValidationFailure("Code", "edit كود اللغة موجود مسبقاً، يرجى إعادة الإدخال")
                       : null;
                });
                CommonRules();
            });

            CommonRules();
        }

        private void CommonRules()
        {
            RuleFor(m => m.Code).NotEmpty().WithMessage("كود اللغة مطلوب").Length(2).WithMessage("الكود مرفوض");

            RuleFor(m => m.ArabicName).NotEmpty().WithMessage("الاسم بالعربية مطلوب").Length(1, 100).WithMessage("طول السلسلة أقل من 100 حرف");
            RuleFor(m => m.EnglishName).NotEmpty().WithMessage("الاسم بالانجليزية مطلوب").Length(1, 100).WithMessage("طول السلسلة أقل من 100 حرف");
        }

    }
}
