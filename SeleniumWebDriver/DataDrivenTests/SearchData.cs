using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver.DataDrivenTests
{
    public class SearchData
    {
        public Int32 Id { get; set; }
        public string SearchTerm { get; set; }
        public bool HasImage { get; set; }
        public bool PostedToday { get; set; }
        public bool IncludeNearby { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }

        public SearchData()
        {

        }
    }
}
