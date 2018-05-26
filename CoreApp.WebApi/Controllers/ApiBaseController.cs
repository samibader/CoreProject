using CoreApp.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace CoreApp.WebApi.Controllers
{
    public class ApiBaseController : ApiController
    {
        protected string lang = "ar";

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            if (!controllerContext.Request.Headers.Contains("lang"))
                controllerContext.Request.Headers.Add("lang", "ar");


            var lang = controllerContext.Request.Headers.GetValues("lang").First();
            if (lang.ToLower() == "en")
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                lang = "en";
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ar-SY");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ar-SY");
                lang = "ar";
            }

            base.Initialize(controllerContext);
        }

        public LanguageHelper CurrentLanguage
        {
            get
            {
                if (ControllerContext.Request.Headers.GetValues("lang").First().ToLower() == "en")
                    return LanguageHelper.ENGLISH;
                else
                    return LanguageHelper.ARABIC;
            }
        }

        public HttpResponseMessage OkMessage(string message)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = message});
        }

        public HttpResponseMessage ErrorMessage(string message)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = message});
        }

        public HttpResponseMessage NotValidMessage(ModelStateDictionary state)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, state);
        }

        public HttpResponseMessage NotFoundMessage(string message)
        {
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = message});
        }
    }
}
