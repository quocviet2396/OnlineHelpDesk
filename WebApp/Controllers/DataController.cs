using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Repositories;
using WebApp.Ultils;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class DataController : Controller
    {
        private readonly IDataService _data;
        private readonly Helper _hideemail;
        public DataController(IDataService data, Helper hideemail)
        {
            _data = data;
            _hideemail = hideemail;
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
            var result = await _data.AllUser(pageNumber, Limit, propertySort, filter) as Paginated<UsersInfo>;
            ViewData["totalPages"] = result.TotalPages;
            ViewData["Count"] = result.Count;
            ViewData["AccCode"] = _data.AccCode().GetAwaiter().GetResult();
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(List<string> student_code)
        {
            var result = await _data.CreateStudent(student_code);
            TempData["response"] = JsonConvert.SerializeObject(result);
            return RedirectToAction("Index");
        }

    }
}

