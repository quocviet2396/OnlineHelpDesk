using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class PasswordController : Controller
    {
        private readonly IAccountService _account;
        public PasswordController(IAccountService account)
        {
            _account = account;
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        { return View(); }

        [HttpGet]
        public IActionResult ChangePassword()
        { return View(); }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var result = await _account.ForgotPassword(email);
            if (result.Success)
            {

                HttpContext.Session.SetString("emailForgot", result.Data);
                return RedirectToAction("ChangePassword");
            }
            else
            {
                TempData["res"] = JsonConvert.SerializeObject(result);
                return View();
            }
        }
    }
}

