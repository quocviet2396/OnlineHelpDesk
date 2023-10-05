using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Ultils
{
    public class Sort<T> : List<T>
    {
        public static async Task<IQueryable<T>> SortAsync(List<T> source, string sort, string? currentFilter, string? date = null, string? category = null, string? status = null, string? supporter = null, string? priority = null)
        {
            var sortResult = sort?.Split("_");
            var data = source.AsQueryable(); // Convert source to IQueryable    

            PropertyInfo propertyInfo = typeof(T).GetProperty(sortResult[1]);

            if (!string.IsNullOrEmpty(priority))
            {
                data = ApplyFilter(data, priority);
            }

            if (!string.IsNullOrEmpty(supporter))
            {
                data = ApplyFilter(data, supporter);
            }

            if (!string.IsNullOrEmpty(category))
            {
                data = ApplyFilter(data, category);
            }
            if (!string.IsNullOrEmpty(status))
            {
                data = ApplyFilter(data, status);
            }
            if (currentFilter != null)
            {
                var filterResult = currentFilter.Split("_");
                var filterPropertyName = filterResult[0];
                var filterValue = filterResult[1];
                data = data.Where(item => item.GetType().GetProperty(filterPropertyName).GetValue(item).ToString().IndexOf(filterValue, StringComparison.OrdinalIgnoreCase) >= 0);
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

        public static IQueryable<T> ApplyFilter(IQueryable<T> query, string filter)
        {
            var filterResult = filter.Split("_");
            var filterPropertyName = filterResult[0];
            var filterValue = filterResult[1];
            query = query.Where(item => item.GetType().GetProperty(filterPropertyName).GetValue(item).ToString().Equals(filterValue));
            return query;
        }

    }
}

