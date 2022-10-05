using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Core.Models.Infrastructure
{
    public class PagedListModel<T> where T : class
    {
        #region ctor

        public PagedListModel(int currentPage, int pageSize)
        {
            QueryOptions = new BaseSearchModel()
            {
                CurrentPage = currentPage,
                PageSize = pageSize
            };

            DataList = new List<T>();
        }

        public PagedListModel()
        {
            QueryOptions = new BaseSearchModel();
            DataList = new List<T>();
        }

        #endregion ctor

        public BaseSearchModel QueryOptions { get; set; }
        public IEnumerable<T> DataList { get; set; }
    }
}
