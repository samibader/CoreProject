using AutoMapper;
using CoreApp.Domain;
using CoreApp.Domain.Entities;
using CoreApp.Services.Dtos;
using CoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoreApp.Services.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LanguageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        public LanguageDto GetLanguageByCode(string code)
        {
            var model = _unitOfWork.LanguageRepository.FindSingleBy(l => l.Code.ToLower() == code.ToLower());
            return Mapper.Map<Language, LanguageDto>(model);
        }


        public int Add(LanguageDto dto)
        {
            var model = Mapper.Map<LanguageDto, Language>(dto);
            _unitOfWork.LanguageRepository.Add(model);
            _unitOfWork.SaveChanges();
            return model.Id;
        }


        public bool Edit(LanguageDto dto)
        {
            var model = Mapper.Map<LanguageDto, Language>(dto);
            _unitOfWork.LanguageRepository.Update(model);
            _unitOfWork.SaveChanges();
            return true;
        }


        public LanguageDto GetById(int id)
        {
            var model = _unitOfWork.LanguageRepository.FindById(id);
            return Mapper.Map<Language, LanguageDto>(model);
        }

        public List<LanguageDto> All()
        {
            var list = _unitOfWork.LanguageRepository.GetAll();
            return Mapper.Map<List<Language>, List<LanguageDto>>(list);
        }

        

        public bool IsCodeUnique(string code, int? editedId)
        {
            List<Language> langs;
            if (editedId.HasValue)
                langs = _unitOfWork.LanguageRepository.FindBy(m => m.Id != editedId);
            else
                langs = _unitOfWork.LanguageRepository.GetAll();

            return !langs.Where(m=>m.Code.ToLower() ==code.ToLower()).Any();
        }
    }
}
