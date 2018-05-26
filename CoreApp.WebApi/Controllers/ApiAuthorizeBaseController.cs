using CoreApp.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;

namespace CoreApp.WebApi.Controllers
{
    public class ApiAuthorizeBaseController : ApiBaseController
    {
        private ApplicationUserManager _userManager;

        public ApiAuthorizeBaseController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager;

            }
        }

        protected Guid getGuid(string value)
        {
            var result = default(Guid);
            Guid.TryParse(value, out result);
            return result;
        }

        protected Guid getCurrentUserGuid()
        {
            var result = default(Guid);
            Guid.TryParse(User.Identity.GetUserId(), out result);
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }
    }
}
