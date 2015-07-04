using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sesshin.Website.Models
{
    public class BaseViewModel
    {
        public string PageTitle { get; set; }
        public string PageDescription { get; set; }
        public string PageKeywords { get; set; }
    }
}