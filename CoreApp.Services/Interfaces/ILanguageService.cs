using CoreApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Services.Interfaces
{
    public interface ILanguageService
    {
        LanguageDto GetLanguageByCode(string code);
        int Add(LanguageDto dto);
        bool Edit(LanguageDto dto);
        LanguageDto GetById(int id);
        List<LanguageDto> All();
        bool IsCodeUnique(string code, int? editedId);
    }
}
