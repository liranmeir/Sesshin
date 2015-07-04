using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Sesshin.Model
{
    public class Article
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DisplayName("שם כתבה")]
        public string Name { get; set; }
        [Required]
        [DisplayName("שם כתבה באנגלית")]
        public string EnglishName { get; set; }

        [DisplayName("כותרת עמוד ")]
        public string PageTitle { get; set; }
        [DisplayName("תאור עמוד")]
        public string PageDescription { get; set; }
        [DisplayName("מילות מפתח -מופרדות בפסיק")]
        public string PageKeywords { get; set; }


        [DisplayName("כותרת")]

        public string Headline { get; set; }
        [DisplayName("תוכן")]
        [AllowHtml]
        public string Content { get; set; }
        [DisplayName("תאריך")]
        public DateTime DateCreated { get; set; }

        public virtual ICollection<BackgroundImage> BackgroundImages { get; set; } 
    }
}