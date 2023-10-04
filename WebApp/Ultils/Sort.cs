using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Ultils
{
    public class Sort<T> : List<T>
    {
        public static async Task<IQueryable<T>> SortAsync(List<T> source, string sort)
        {
            var sortResult = sort?.Split("_");
            var data = source.AsQueryable(); // Convert source to IQueryable    

            PropertyInfo propertyInfo = typeof(T).GetProperty(sortResult[1]);
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

