using LibraryModels;
using Microsoft.EntityFrameworkCore;
using WebApp.Database_helper;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class NewsServiceImp : INewsService
    {
        private DatabaseContext db;
        public NewsServiceImp(DatabaseContext db)
        {
            this.db = db;
        }

        public void CreateNews(News news, string email)
        {
            try
            {
                news.PublishDate = DateTime.Now;
                news.Author = email;
                db.News.Add(news);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> addNews(News newNews, string email)
        {
            newNews.Author = email;
            await db.News.AddAsync(newNews);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<News> GetNewsById(int id)
        {
            return await db.News.FirstOrDefaultAsync(n => n.ID == id);
        }

        public async Task<IEnumerable<News>> GetNewsList()
        {
            return await db.News.ToListAsync();
        }

        public async Task<bool> removeNews(int id)
        {
            var news = await db.News.FirstOrDefaultAsync(n => n.ID == id);
            if (news != null)
            {
                db.News.Remove(news);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> updateNews(News newNews)
        {
            var news = await db.News.FirstOrDefaultAsync(n => n.ID == newNews.ID);
            if (news != null)
            {
                news.Title = newNews.Title;
                news.Content = newNews.Content;
                news.Author = newNews.Author;
                news.PublishDate = newNews.PublishDate;
                news.Img = newNews.Img;

                await db.SaveChangesAsync();
                return true;
            }
            else { return false; }
        }
    }
}