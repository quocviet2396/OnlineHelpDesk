﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApp.Repositories;
using WebApp.Ultils;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        public class MyDataModel
        {
            public string InputValue { get; set; }
            public string AdditionalValue { get; set; }
        }
        private readonly Helper _helper;
        private readonly IAccountService _account;
        public AccountController(IAccountService account, Helper helper)
        {
            _account = account;
            _helper = helper;
        }

        public async Task<IActionResult> Index(int pageIndex, int? limit, string? currentSort)
        {
            var Limit = limit ?? 7;

            var propertySort = string.IsNullOrEmpty(currentSort) ? null : currentSort.Split("_")[0] == "desc" ? $"asc_{currentSort.Split("_")[1]}" : $"desc_{currentSort.Split("_")[1]}";
            ViewData["propertySort"] = propertySort;
            ViewData["nameSort"] = propertySort?.Split("_")[1];

            var pageNumber = pageIndex <= 0 ? 1 : pageIndex;
            var result = await _account.AllUsers(pageNumber, Limit, propertySort) as Paginated<Users>;
            ViewData["totalPages"] = result.TotalPages;
            ViewData["Count"] = result.Count;
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> UserProfile()
        {
            var email = HttpContext.Session.GetString("accEmail");
            var user = await _account.UserProfile(email);
            ViewData["UserProfile"] = user;
            //var result = JsonConvert.DeserializeObject(user);
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ResetPassword(string code)
        {
            var result = await _account.ResetPassword(code);
            if (result.Success == true && result.Msg == "Success")
            {
                TempData["res"] = JsonConvert.SerializeObject(result);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public async Task<JsonResult> UserInfo(string id)
        {
            var model = await _account.UserInfo(id);
            Users result = new Users()
            {
                Id = model.Id,
                Email = _helper.AnEmail(model.Email, 4),
                Password = model.Password,
                Code = model.Code,
                Role = model.Role,
                Discussions = model.Discussions,
                Status = model.Status
            };
            var user = JsonConvert.SerializeObject(result);
            return Json(user);
        }


        [HttpPost]
        public async Task<JsonResult> CheckPassword(IFormCollection data)
        {
            var additionalValue = data["additionalValue"];
            var inputValue = data["inputValue"];
            var accCode = data["accCode"];
            var newPas = data["newPass"];
            var conPas = data["conPass"];
            var res = await _account.CheckPassword(inputValue, additionalValue, accCode, newPas, conPas);
            var result = JsonConvert.SerializeObject(res);
            return Json(result);
        }


        [HttpPost]
        public async Task<JsonResult> ChangePassword(IFormCollection newPassword)
        {
            var accCode = newPassword["accCode"];
            var newPas = newPassword["newPass"];
            var res = await _account.ChangePassword(newPas, accCode);
            var result = JsonConvert.SerializeObject(res);
            return Json(result);
        }
    }
}

