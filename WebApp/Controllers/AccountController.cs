﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApp.Authorize;
using WebApp.Repositories;
using WebApp.Ultils;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private readonly Helper _helper;
        private readonly IAccountService _account;
        private readonly IAuthenService _authen;
        public AccountController(IAccountService account, Helper helper, IAuthenService authen)
        {
            _account = account;
            _helper = helper;
            _authen = authen;
        }

        public async Task<IActionResult> Index(int pageIndex, int? limit, string? currentSort, string? currentFilter)
        {
            var Limit = limit ?? 7;

            var filter = string.IsNullOrEmpty(currentFilter) ? null : currentFilter;

            ViewData["currentFilter"] = filter;

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
            var stucode = HttpContext.Session.GetString("accCode");
            var stuEmail = HttpContext.Session.GetString("accEmail");
            var stuRole = HttpContext.Session.GetString("accRole");
            TempData["AccRole"] = stuRole == "Admin" || stuRole == "Supporter" ? "_BackendLayout" : "_BackendLayout";
            var model = _account.UserInfo(stucode);
            if (model != null)
            {
                UserInfoDTO result = new UserInfoDTO()
                {
                    Id = model.Id,
                    Email = _helper.AnEmail(model.Email, 4),
                    UserName = model.UserName,
                    Password = model.Password,
                    Code = model.Code,
                    Role = model.Role,
                    DateOfBirth = model.DateOfBirth,
                    Status = model.Status,
                    Gender = model.Gender,
                    Phone = model.Phone,
                    Photo = model.Photo,
                    Address = model.Address,
                    City = model.City
                };
                ViewData["UserDtoProfile"] = result;
                //var result = JsonConvert.DeserializeObject(user);
                return View();
            }
            else
            {
                var user = await _account.users(stuEmail);
                ViewData["UserProfile"] = user;
                //var result = JsonConvert.DeserializeObject(user);
                return View();
            }
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
        public async Task<JsonResult> UserInfo(string stuCodeId)
        {
            var model = _account.UserInfo(stuCodeId);
            if (model != null)
            {
                UserInfoDTO result = new UserInfoDTO()
                {
                    Id = model.Id,
                    Email = _helper.AnEmail(model.Email, 4),
                    UserName = model.UserName,
                    Password = model.Password,
                    Code = model.Code,
                    Role = model.Role,
                    DateOfBirth = model.DateOfBirth,
                    Status = model.Status,
                    Gender = model.Gender,
                    Phone = model.Phone,
                    Photo = model.Photo,
                    Address = model.Address,
                    City = model.City
                };
                var user = JsonConvert.SerializeObject(result);
                return Json(new { Success = false, Msg = "", data = user });
            }
            else
            {
                return Json(new { Success = false, Msg = "Chua co thong tin" });
            }

        }


        [HttpPost]
        public async Task<JsonResult> CheckPassword(IFormCollection data)
        {
            var additionalValue = data["additionalValue"];
            var inputValue = data["inputValue"];
            var code = HttpContext.Session.GetString("emailForgot");
            var accCode = data["accCode"].FirstOrDefault() != null ? data["accCode"].FirstOrDefault() : code;
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
            if (res.Success)
            {
                HttpContext.Session.Remove("accCode");
                HttpContext.Session.Remove("accEmail");
            }
            var result = JsonConvert.SerializeObject(res);
            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> CreateAccount(IFormCollection data)
        {
            var res = await _account.CreateAccount(data);
            var result = JsonConvert.SerializeObject(res);
            return Json(result);
        }


        [HttpPost]
        public async Task<JsonResult> CheckPhoto(IFormCollection data)
        {
            var res = await _account.CheckPhoto(data.Files["Photo"]);
            var result = JsonConvert.SerializeObject(res);
            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> InfoChange(IFormCollection form)
        {
            var res = await _account.InfoChange(form);
            var result = JsonConvert.SerializeObject(res);
            return Json(result);
        }

        [HttpGet]
        [Route("/ForgotPass")]
        public IActionResult ForgotPassword()
        { return View(); }

        [HttpGet]
        [Route("/ChangePassword")]
        public IActionResult ChangePassword()
        { return View(); }

        [HttpPost]
        [Route("/ForgotPass")]
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

        [HttpPost]
        public async Task<JsonResult> ChangeAvatar(IFormCollection avatar)
        {
            var res = await _account.ChangeAvatar(avatar);
            var result = JsonConvert.SerializeObject(res);
            return Json(result);
        }
    }
}

