using CoreApp.Services.Dtos.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Services.Dtos
{
    //[Validator(typeof(RegisterUserValidator))]
    public class RegisterUserDto
    {
        /// <summary>
        /// emaillllllllllll
        /// </summary>
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
