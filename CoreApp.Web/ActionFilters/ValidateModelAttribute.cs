using FluentValidation;
using FluentValidation.Internal;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.ActionFilters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var actionArgument = GetTheActionArgument(actionContext);
            if (actionArgument == null)
            {
                //return;
                //var response = actionContext.HttpContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Element is null");
                actionContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest,"Element is null");
                return;
            }

            Type validatorType = GetValidatorType(actionArgument.GetType());
            IValidator validator =
                (IValidator)DependencyResolver.Current.GetService(validatorType);

            if (validator == null)
            {
                actionContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Validator is not specified");
                return;
            }

            string actionName = actionContext.ActionDescriptor.ActionName;

            var validationContext = new ValidationContext(actionArgument, new PropertyChain(),
                    new RulesetValidatorSelector(actionName));
            var validationResult =
                validator.Validate(validationContext);
            if (validationResult.IsValid) return;

            // Add the errors from our validation into the modelstate.
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    actionContext.Controller.ViewData.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                //ValidationException e = new ValidationException()
                //var errorResponse = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
                //throw new HttpResponseException(errorResponse);
            }
            throw new System.ComponentModel.DataAnnotations.ValidationException();
            //throw new System.ComponentModel.DataAnnotations.ValidationException();
            //throw new HttpResponseException(actionContext.Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, actionContext.ModelState));
            //var errorResponse = actionContext.Request.CreateErrorResponse(
            //throw new HttpResponseException(errorResponse);
            //ResponseMessageHelper.CreateBadRequestResponse(validationResult);
        }

        private static object GetTheActionArgument(ActionExecutingContext actionContext)
        {
            return actionContext.ActionParameters.SingleOrDefault().Value;
        }

        private Type GetValidatorType(Type type)
        {
            if (type == null) return null;

            var abstractValidatorType = typeof(AbstractValidator<>);
            var validatorForType = abstractValidatorType.MakeGenericType(type);

            var types = AllClasses.FromLoadedAssemblies().
                Where(t => validatorForType.IsAssignableFrom(t)).ToList();

            if (types.Any())
            {
                return types.FirstOrDefault();
            }

            return null;
        }
    }
}