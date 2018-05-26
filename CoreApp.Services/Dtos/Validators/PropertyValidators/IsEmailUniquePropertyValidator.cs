using CoreApp.Services.Interfaces;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Services.Dtos.Validators.PropertyValidators
{
    public class IsEmailUniquePropertyValidator : PropertyValidator
    {
        public readonly IUserService _userService;
        public IsEmailUniquePropertyValidator(IUserService userService)
            : base("البريد الالكتروني غير متاح ! server")
        {
            _userService = userService;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string email = context.PropertyValue as string;
            RegisterUserDto m = context.Instance as RegisterUserDto;
            
            return _userService.IsEmailUnique(m.Email);
        }
    }
}
