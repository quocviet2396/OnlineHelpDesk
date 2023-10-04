using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Ultils
{
    public class Sort<T> : List<T>
    {
        public static async Task<IQueryable<T>> SortAsync(List<T> source, string sort, string? currentFilter)
        {
            var sortResult = sort?.Split("_");
            var data = source.AsQueryable(); // Convert source to IQueryable    

            PropertyInfo propertyInfo = typeof(T).GetProperty(sortResult[1]);

            if (currentFilter != null)
            {
                var filterResult = currentFilter.Split("_");
                var filterPropertyName = filterResult[0];
                var filterValue = filterResult[1];

                // Thực hiện câu lệnh where
                data = data.Where(item => item.GetType().GetProperty(filterPropertyName).GetValue(item).ToString().Contains(filterValue));
            }
            switch (sortResult[0])
            {
                case "desc":
                    data = data.OrderBy(s => propertyInfo.GetValue(s, null)).AsQueryable();
                    break;
                default:
                    data = data.OrderByDescending(s => propertyInfo.GetValue(s, null)).AsQueryable();
                    break;
            }

            // Await the completion of the ordering operation and return the IQueryable
            return data;
        }

    }
}