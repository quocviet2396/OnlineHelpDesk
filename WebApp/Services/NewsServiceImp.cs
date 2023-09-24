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
                    /*// Đặt ngày tạo tin tức là ngày hiện tại
                    news.CreatedDate = DateTime.Now;*/

                    // Thêm tin tức mới vào DbSet trong DbContext
                   db.News.Add(news);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu cần thiết
                    // Ví dụ: Ghi log lỗi hoặc thông báo lỗi cho người dùng
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
                    // Tìm tin tức cần cập nhật dựa trên Id
                    var existingNews = db.News.Find(news.Id);

                    // Kiểm tra xem tin tức có tồn tại không
                    if (existingNews != null)
                    {
                        // Cập nhật thông tin tin tức
                        existingNews.Title = news.Title;
                        existingNews.Content = news.Content;

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
        }
}