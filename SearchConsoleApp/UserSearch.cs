using SearchConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchConsoleApp
{
    public class UserSearch
    {
        private ISearch _search = null;

        public UserSearch(ISearch search)
        {
            _search = search;
        }
        public int MakeSearch(string query)
        {
            var result = _search.Search(query);
            return result;
        }


    }
}
