using AutoMapper;
using CoreApp.Common;
using CoreApp.Domain;
using CoreApp.Domain.Entities;
using CoreApp.Services.Dtos;
using CoreApp.Services.Identity;
using CoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationUserManager _userManager;
        public UserService(IUnitOfWork unitOfWork, ApplicationUserManager userManager)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager; }
        }

        public Guid Add(UserDto dto)
        {
            var model = Mapper.Map<UserDto, User>(dto);
            _unitOfWork.UserRepository.Add(model);
            _unitOfWork.SaveChanges();
            return model.UserId;
        }
        public bool Edit(UserDto dto)
        {
            User user = Mapper.Map<UserDto, User>(dto);
            if (user == null)
                return false;
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Delete(Guid id)
        {
            User user = _unitOfWork.UserRepository.FindById(id);
            if (user == null)
                return false;
            _unitOfWork.UserRepository.Remove(user);
            _unitOfWork.SaveChanges();
            return true;
        }

        public UserDto GetById(Guid id)
        {
            var model = _unitOfWork.UserRepository.FindById(id);
            return Mapper.Map<User, UserDto>(model);
        }

        public List<UserDto> GetAll()
        {
            return Mapper.Map<List<User>, List<UserDto>>(_unitOfWork.UserRepository.GetAll());
        }
        public bool HasRole(Guid id,String role)
        {
            return GetById(id).Role == role;
        }
        public bool Exists(Guid id)
        {
            return GetById(id) == null ? false : true;
        }


        public List<UserDto> GetUsersByRole(string role)
        {
            return GetAll().AsEnumerable().Where(u => HasRole(u.UserId, role)).ToList();
        }

        public bool IsEmailUnique(string email)
        {
            return _unitOfWork.UserRepository.FindByEmail(email.ToLower()) == null;
        }


        public async Task<bool> RegisterUser(RegisterUserDto dto)
        {
            var user = new IdentityUser { UserName = dto.Email, Email = dto.Email, CreationDate = Utils.ServerNow };
            var result = await UserManager.CreateAsync(user, dto.Password);
        }
    }
}
