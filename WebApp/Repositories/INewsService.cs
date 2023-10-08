/*using LibraryModels;

namespace WebApp.Repositories
{
    public interface INewsService
    {
        IEnumerable<News> GetAllNews();

        // Lấy thông tin chi tiết của một tin tức dựa trên ID

        Task<News> GetNewsById(int id);

        // Tạo một tin tức mới
        void CreateNews(News news, string email);

        // Cập nhật thông tin của một tin tức
        void UpdateNews(News news);

        // Xóa một tin tức dựa trên ID
        void DeleteNews(int id);

        // Thêm một bình luận cho một tin tức
        void AddCommentToNews(int newsId, Comments comment);
        void UpdateNews(int id);
        Task CreateNews(News news);
    }
}
*/

using LibraryModels;

namespace WebApp.Repositories
{
    public interface INewsService
    {
        Task<IEnumerable<News>> GetNewsList();
        Task<News> GetNewsById(int id);

        Task<bool> addNews(News newNews);
        Task<bool> removeNews(int id);
        Task<bool> updateNews(News newNews);
    }
}
