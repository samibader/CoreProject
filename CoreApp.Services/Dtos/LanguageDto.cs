using FluentValidation.Attributes;
using CoreApp.Services.Dtos.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Services.Dtos
{
    //[Validator(typeof(LanguageValidator))]
    public class LanguageDto
    {
        /// <summary>
        /// Id required for edit not for insert
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Code should be 2 length only
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// required , Maximum 100 characters length 
        /// </summary>
        public string ArabicName { get; set; }
        /// <summary>
        /// required , Maximum 100 characters length 
        /// </summary>
        public string EnglishName { get; set; }
    }
}
