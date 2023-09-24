using LibraryModels;

namespace WebApp.Repositories
{
    public interface INewsService
    {
        IEnumerable<News> GetAllNews();

        // Lấy thông tin chi tiết của một tin tức dựa trên ID
        News GetNewsById(int id);

        // Tạo một tin tức mới
        void CreateNews(News news);

        // Cập nhật thông tin của một tin tức
        void UpdateNews(News news);

        // Xóa một tin tức dựa trên ID
        void DeleteNews(int id);

        // Thêm một bình luận cho một tin tức
        void AddCommentToNews(int newsId, Comments comment);
        void UpdateNews(int id);
    }
}
