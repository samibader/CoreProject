using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CoreApp.Web.Models;
using CoreApp.Services.Identity;
using CoreApp.Common;
using CoreApp.Services.Dtos;
using FluentValidation.Mvc;
using CoreApp.Services.Interfaces;

namespace CoreApp.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

       
        //
        // GET: /Account/Register
        [AllowAnonymous]
        [RuleSetForClientSideMessages("Register")]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [RuleSetForClientSideMessages("Register")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([CustomizeValidator(RuleSet = "Register")] RegisterUserDto model)
        {

            //if (ModelState.IsValid)
            //{
                //var user = new IdentityUser { UserName = model.Email, Email = model.Email, CreationDate = Utils.ServerNow };
                //var result = await UserManager.CreateAsync(user, model.Password);
                //if (result.Succeeded)
                //{
                //    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                //    // Send an email with this link
                //    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                //    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                //    await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                //    // Email Confirmation
                //    TempData["ViewBagLink"] = callbackUrl;
                //    ViewBag.Message = "Check your email and confirm your account, you must be confirmed "
                //         + "before you can log in.";
                //    return View("Info");
                //    //

                //    //return RedirectToAction("Index", "Home");
                //}
                //AddErrors(result);
            //}

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        
    }
}