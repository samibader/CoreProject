using CoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoreApp.WebApi.Controllers
{
    [RoutePrefix("api/Validation")]
    public class ValidationController : ApiController
    {
        private readonly IUserService _userService;

        public ValidationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> IsEmailUnique(string email)
        {
            bool validationResult = true;

            if (!String.IsNullOrEmpty(email))
            {
                validationResult = _userService.IsEmailUnique(email);
            }

            return Ok(validationResult);
        }
    }
}
