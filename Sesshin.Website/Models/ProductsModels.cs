using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sesshin.Website.Models
{
    public class PricesViewModel:BaseViewModel
    {
        public List<PriceLinkBox> LinkBoxes { get; set; }
        public List<string> BackgroundImages { get; set; }

        public PricesViewModel()
        {
            LinkBoxes = new List<PriceLinkBox>();
        }
    }
}
