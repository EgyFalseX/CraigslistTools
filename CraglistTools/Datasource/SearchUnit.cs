using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraigslistTools.Datasource
{
    public class SearchUnit
    {
        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _category;
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public SearchUnit(string city, string craigslist, string category, string keyword)
        {
            _city = city;
            _category = category;
            _url = GetSearchUrl(city, craigslist, category, keyword);
        }
        private string GetSearchUrl(string city, string craigslist, string category, string keyword)
        {
            string output = string.Empty;
            output = string.Format("http://" + city + "." + craigslist + "/search/" + category + "?query=" + keyword);
            return output;
        }


    }
}
