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

        public async Task<bool> addNews(News newNews, string email)
        {
            newNews.Status = 1;
            newNews.Author = email;
            newNews.PublishDate = DateTime.Now;
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
            return await db.News.Where(i => i.Status.Equals(1)).ToListAsync();
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
                news.Status = newNews.Status;
                await db.SaveChangesAsync();
                return true;
            }
            else { return false; }
        }

        public Task<bool> AddComment(News newNews)
        {
            throw new NotImplementedException();
        }

        /*public async Task<List<Comment>> GetCommentById(int id)
        {
            var comments = await db.Comments
        .Where(c => c.Id == id)
        .ToListAsync();

            return comments;
        }*/

        public async Task<IEnumerable<Comment>>GetCommentList()
        {
            return await db.Comments.ToListAsync();

        }

        public Task<News> GetCommentById(int id)
        {
            throw new NotImplementedException();
        }

        /*Task<News> INewsService.GetCommentById(int id)
        {
            throw new NotImplementedException();
        }*/
    }
}