using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Sesshin.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("שם מוצר")]
        public string Name { get; set; }

        [Required]
        [DisplayName("שם מוצר באנגלית")]
        public string EnglishName { get; set; }

        [DisplayName("תאור")]
        [AllowHtml]
        public string Description { get; set; }
        [DisplayName("קבצי רקע")]
        public string BackgroundFiles { get; set; }
        [DisplayName("תאריך עדכון")]
        public DateTime DateModified { get; set; }

        [DisplayName("כותרת עמוד ")]
        public string PageTitle { get; set; }
        [DisplayName("תאור עמוד")]
        public string PageDescription { get; set; }
        [DisplayName("מילות מפתח -מופרדות בפסיק")]
        public string PageKeywords { get; set; }

        public virtual ICollection<PriceModel> PriceModels { get; set; }
        public virtual ICollection<BackgroundImage> BackgroundImages { get; set; } 
    }
}