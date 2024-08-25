using LibraryModels;

namespace WebApp.Repositories
{
    public interface IQnAService
    {
        Task<IEnumerable<QnA>> GetAll();
        Task<QnA> GetById(int id);
        Task<bool> addQnA(QnA newQna);
        Task<bool> removeQnA(int id);
        Task<bool> updateQnA(QnA editQna);
    }
}
