using LibraryModels;

namespace WebApp.Repositories
{
    public interface INewsService
    {
        Task<IEnumerable<News>> GetNewsList();
        Task<News> GetNewsById(int id);

        Task<News> GetCommentById(int id);

        Task<bool> addNews(News newNews, string email);

        Task<bool> removeNews(int id);
        Task<bool> updateNews(News newNews);
        Task<bool> AddComment(News newNews);

    }
}
