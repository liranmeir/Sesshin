using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sesshin.Website.Models
{
    public class PriceLinkBox:LinkBoxModel
    {
        public string Description { get; set; }
        public string Minutes { get; set; }
        public string Price { get; set; }
    }
}