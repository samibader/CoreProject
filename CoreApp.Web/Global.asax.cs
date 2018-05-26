using CoreApp.Services;
using CoreApp.Services.Dtos.Validators;
using CoreApp.Services.Dtos.Validators.PropertyValidators;
using CoreApp.Web.Models;
using CoreApp.Web.Models.Validators;
using FluentValidation.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CoreApp.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize Mapper
            DtoMappings.Initialize();

            //Initialise Bootstrapper
            Bootstrapper.Initialise();

            FluentValidationModelValidatorProvider.Configure(
              provider =>
              {
                  provider.ValidatorFactory = new DependencyResolverModelValidatorFactory();
                  provider.Add(
                  typeof(IsEmailUniquePropertyValidator),
                  (metadata, context, rule, validator) => new IsEmailUniqueClientPropertyValidator(metadata, context, rule, validator));
                              });
            //FluentValidationModelValidatorProvider.Configure();
        }
    }
}
