using LibraryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Database_helper;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class FrontendController : Controller
    {
        private readonly ILogger<FrontendController> logger;
        private readonly IQnAService qnAService;
        private readonly INewsService service;
        private readonly DatabaseContext dbContext;

        public FrontendController(ILogger<FrontendController> logger, IQnAService qnAService, INewsService service, DatabaseContext dbContext)
        {
            this.logger = logger;
            this.qnAService = qnAService;
            this.service = service;
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> QnA()
        {
            var qna = await qnAService.GetAll();
            return View(qna);
        }
        public async Task<IActionResult> QnADetail(int id)
        {
            var qna = await qnAService.GetById(id);
            if (qna == null)
            {
                return NotFound();
            }
            return View(qna);
        }

        [HttpGet]
        public async Task<IActionResult> News()
        {
            var news = await service.GetNewsList();
            return View(news);
        }
        [HttpGet]
        public async Task<IActionResult> NewsDetail(int id)
        {

            var newsItem = await service.GetNewsById(id);

            if (newsItem == null)
            {
                return NotFound();
            }
            var commemt = await dbContext.Comments.Where(i => i.NewId == id).OrderByDescending(a => a.Date).ToListAsync();
            ViewBag.Reviews = commemt;
            return View(newsItem);
        }
        [HttpPost]
        public IActionResult AddComment(int mewId, string cmt)
        {
            try
            {
                // Danh sách từ khoá cấm
                List<string> bannedKeywords = new List<string> { "Thuốc lá", "Mụn", "Sẹo”", "Yếu sinh lý", "Các bộ phận nhạy cảm của con người",
                    "Giảm cân", "Tăng cân", "Rượu", "Xương", "Khớp", "Viêm Xoang", "Thực phẩm chức năng", "Ăn kiêng", "Hộ chiếu", "Bằng lái xe",
                    "Sổ đỏ", "Sổ hộ khẩu", "Hẹn hò", "đm", "mẹ", "chó", "fat loss", "mortgages", "payday loans", "anti-aging", "marijuana",
                    "2 girls 1 cup", "2g1c", "4r5e", "5h1t", "5hit", "a_s_s", "a55", "acrotomophilia", "alabama hot pocket", "alaskan pipeline",
                    "anal", "anilingus", "anus", "apeshit", "ar5e", "arrse", "arse", "arsehole", "ass", "ass - fucker", "ass - hat", "ass - jabber",
                    "ass - pirate", "assbag", "assbandit", "assbanger", "assbite", "assclown", "asscock", "asscracker", "asses", "assface", "assfuck",
                    "assfucker", "assfukka", "assgoblin", "asshat", "asshead", "asshole", "assholes", "asshopper", "assjacker", "asslick", "asslicker",
                    "assmonkey", " assmunch", "assmuncher, assnigger, asspirate, assshit, assshole, asssucker, asswad, asswhole, asswipe, auto erotic, autoerotic, axwound, b!tch, b00bs, b17ch, b1tch, babeland, baby batter, baby juice, ball gag, ball gravy, ball kicking, ball licking, ball sack, ball sucking, ballbag, balls, ballsack, bampot, bangbros, bareback, barely legal, barenaked, bastard, bastardo, bastinado, bbw, bdsm, beaner, beaners, beastial, beastiality, beaver cleaver, beaver lips, bellend, bestial, bestiality, bi + ch, biatch, big black, big breasts, big knockers, big tits, bimbos, birdlock, bitch, bitchass, bitcher, bitchers, bitches, bitchin, bitching, bitchtits, bitchy, black cock, blonde action, blonde on blonde action, bloody, blow job, blow your load, blowjob, blowjobs, blue waffle, blumpkin, boiolas, bollock, bollocks, bollok, bollox, bondage, boner, boob, boobs, booobs, boooobs, booooobs, booooooobs, booty call, breasts, breeder, brotherfucker, brown showers, brunette action, buceta, bugger, bukkake, bulldyke, bullet vibe, bullshit, bum, bumblefuck, bung hole, bunghole, bunny fucker, busty, butt, butt plug, butt - pirate, buttcheeks, buttfucka, buttfucker, butthole, buttmuch, buttplug, c0ck, c0cksucker, camel toe, camgirl, camslut, camwhore, carpet muncher, carpetmuncher, cawk, chesticle, chinc, chink, choad, chocolate rosebuds, chode, cipa, circlejerk, cl1t, cleveland steamer, clit, clitface, clitfuck, clitoris, clits, clover clamps, clusterfuck, cnut, cock, cock - sucker, cockass, cockbite, cockburger, cockeye, cockface, cockfucker, cockhead, cockjockey, cockknoker, cocklump, cockmaster, cockmongler, cockmongruel, cockmonkey, cockmunch, cockmuncher, cocknose, cocknugget, cocks, cockshit, cocksmith, cocksmoke, cocksmoker, cocksniffer, cocksuck, cocksucked, cocksucker" };

                // Kiểm tra từ khoá cấm trong comment
                bool containsBannedKeyword = bannedKeywords.Any(keyword => cmt.Contains(keyword, StringComparison.OrdinalIgnoreCase));
                if (containsBannedKeyword)
                {
                    // Comment có từ khoá cấm, xử lý theo mong muốn của bạn (ví dụ: từ chối lưu trữ hoặc thông báo lỗi)
                    return RedirectToAction("NewsDetail", new { id = mewId });
                }
                var useremail = HttpContext.Session.GetString("accEmail");
                var user = dbContext.Users.FirstOrDefault(a => a.Email.Equals(useremail));
                Comment comment = new Comment()
                {
                    Text = cmt,
                    Date = DateTime.Now,
                    UserName = user.UserName,
                    NewId = mewId,
                };
                dbContext.Comments.Add(comment);
                dbContext.SaveChanges();
                return RedirectToAction("NewsDetail", new { id = mewId });
            }
            catch (Exception)
            {
                return RedirectToAction("NewsDetail");
            }
        }
    }
}
