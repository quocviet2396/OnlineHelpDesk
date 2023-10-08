using LibraryModels;
using Microsoft.EntityFrameworkCore;
using WebApp.Database_helper;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class QnAServiceImp : IQnAService
    {
        private DatabaseContext db;
        public QnAServiceImp(DatabaseContext db)
        {
            this.db = db;
        }
        public async Task<bool> addQnA(QnA newQna)
        {
            await db.QnA.AddAsync(newQna);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<QnA>> GetAll()
        {
            return await db.QnA.ToListAsync();
        }

        public async Task<QnA> GetById(int id)
        {
            return await db.QnA.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<bool> removeQnA(int id)
        {
            var model = await db.QnA.SingleOrDefaultAsync(q => q.Id == id);
            if(model != null)
            {
                db.QnA.Remove(model);
                await db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateQnA(QnA editQna)
        {
            var model = await db.QnA.SingleOrDefaultAsync(q => q.Id == editQna.Id);
            if(model != null)
            {
                model.Title = editQna.Title;
                model.Content = editQna.Content;
                await db.SaveChangesAsync();
                return true;
            }
            else { return false; }
        }
    }
}
