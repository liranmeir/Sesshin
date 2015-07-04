using System.Collections.Generic;
using Sesshin.Service;

namespace Sesshin.Website.Models
{
    public class ProductsDetailsViewModel : BaseViewModel
    {
        public int ProductId { get; set; }
        public string ProductName;
        public string EnglishName;
        public string Text;
        public bool IsDisplayPriceLink;
        public List<string> BackgroundImages;
      
    }
}