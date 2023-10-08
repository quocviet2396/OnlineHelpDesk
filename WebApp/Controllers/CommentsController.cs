using Microsoft.AspNetCore.Mvc;
using WebApp.Database_helper;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class CommentsController : Controller
    {
        private IAuthenService _authenService;
        private INewsService service;
        private DatabaseContext dbContext;
        
    }
}
