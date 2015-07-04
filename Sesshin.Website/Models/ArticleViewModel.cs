using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sesshin.Website.Models
{
    public class ArticleViewModel : BaseViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Headline { get; set; }
        public string Content { get; set; }

        public ICollection<string> BackgroundImages { get; set; } 
    }
}