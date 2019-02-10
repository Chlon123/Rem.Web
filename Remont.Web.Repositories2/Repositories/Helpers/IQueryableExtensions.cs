using Remont.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace Remont.Web.Repositories2.Repositories.RepositoryHelpers
{
    public static class IQueryableExtensions
    {
      public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string sort)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (sort == null)
            {
                return source;
            }

            //split this sort string
            string[] lstSort = sort.Split(',');

            // run through the sorting options and create a sort expression string from

            string completeSortExpression = "";

            foreach (var sortOption in lstSort)
            {
                // if the sort option starts with "-" we order descending, otherwise ascending
                if (sortOption.StartsWith("-"))
                {
                    completeSortExpression = completeSortExpression + sortOption.Remove(0, 1) + " descending,";
                }
                else
                {
                    completeSortExpression = completeSortExpression + sortOption + ",";
                }
            }

            if (!string.IsNullOrWhiteSpace(completeSortExpression))
            {
                source = source.OrderBy(completeSortExpression.Remove(completeSortExpression.Count() - 1));
            }
            return source;
        }
            


    }
}
