using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Ultils
{
    public class Paginated<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int Count { get; set; }
        public Paginated(List<T> items, int count, int pageIndex, int pageSize)
        {
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageIndex = pageIndex <= 0 ? 1 : pageIndex;
            Count = count;
            this.AddRange(items);
        }



        public static async Task<Paginated<T>> CreatePaginate(List<T> source, int pageIndex, int limit, Expression<Func<T, object>> orderBy = null)
        {
            var offset = (pageIndex == null || pageIndex <= 1) ? 0 : pageIndex - 1;
            var count = source.Count();
            // Áp dụng trình tự sắp xếp nếu có
            var query = source.AsQueryable();
            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }

            var items = source.Skip(offset * limit).Take(limit).ToList();

            return new Paginated<T>(items, count, pageIndex, limit);
        }
    }
}

