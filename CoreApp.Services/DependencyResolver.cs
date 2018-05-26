using CoreApp.Data;
using CoreApp.Domain;
using CoreApp.Resolver;
using CoreApp.Services.Dtos;
using CoreApp.Services.Dtos.Validators;
using CoreApp.Services.Identity;
using CoreApp.Services.Interfaces;
using CoreApp.Services.Services;
using FluentValidation;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CoreApp.Services
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterTypeWithInjectedConstructor<IUnitOfWork, UnitOfWork>("CoreApp");
            registerComponent.RegisterTypeWithTransientLifetimeManager<IUserStore<IdentityUser, Guid>, UserStore>();
            registerComponent.RegisterTypeWithTransientLifetimeManager<IRoleStore<IdentityRole,Guid>,RoleStore>();

            // Services
            registerComponent.RegisterType<ILanguageService, LanguageService>();
            registerComponent.RegisterType<IUserService,UserService>();
            

            // Validators
            registerComponent.RegisterType<IValidator<LanguageDto>, LanguageValidator>();
            registerComponent.RegisterType<IValidator<RegisterUserDto>, RegisterUserValidator>();
            
        }
    }
}
