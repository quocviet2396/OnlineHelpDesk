using LibraryModels;
using Microsoft.EntityFrameworkCore;
using WebApp.Database_helper;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class NewsServiceImp: INewsService
    {
            private DatabaseContext db;
            public NewsServiceImp(DatabaseContext db)
            {
                this.db = db;
            }

            public void AddCommentToNews(int newsId, Comments comment)
            {
                throw new NotImplementedException();
            }

            public void CreateNews(News news)
            {
                try
                {
                    news.PublishDate = DateTime.Now;
                   db.News.Add(news);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            public void DeleteNews(int id)
            {
                try
                {
                    // Tìm tin tức cần xóa dựa trên id
                    var newsToDelete = db.News.Find(id);

                    // Kiểm tra xem tin tức có tồn tại không
                    if (newsToDelete != null)
                    {
                        // Xóa tin tức khỏi DbSet trong DbContext
                        db.News.Remove(newsToDelete);

                        // Lưu thay đổi vào cơ sở dữ liệu
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu cần thiết
                    // Ví dụ: Ghi log lỗi hoặc thông báo lỗi cho người dùng
                    throw ex;
                }
            }

            public IEnumerable<News> GetAllNews()
            {
                var newsList = db.News.ToList();

                return newsList;
            }
            

            public News GetNewsById(int id)
            {
                {
                    var newsList = db.News.Find(id);

                    return newsList ;
                }
            }

            public void UpdateNews(News news)
            {
                try
                {
                    var existingNews = db.News.Find(news.Id);

                    if (existingNews != null)
                    {
                        existingNews.Title = news.Title;
                        existingNews.Content = news.Content;

                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        public void UpdateNews(int id, News news)
        {
            db.News.Update(news);
            db.SaveChangesAsync();
            return;
        }

        public async Task<bool> editTicketStatus(TicketStatus newTicketStatus)
        {
            db.TicketStatus.Update(newTicketStatus);
            await db.SaveChangesAsync();
            return true;
        }

        public void UpdateNews(int id)
        {
            throw new NotImplementedException();
        }
    }
}