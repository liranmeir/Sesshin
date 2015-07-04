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
        [DisplayName("�� ����")]
        public string Name { get; set; }

        [Required]
        [DisplayName("�� ���� �������")]
        public string EnglishName { get; set; }

        [DisplayName("����")]
        [AllowHtml]
        public string Description { get; set; }
        [DisplayName("���� ���")]
        public string BackgroundFiles { get; set; }
        [DisplayName("����� �����")]
        public DateTime DateModified { get; set; }

        [DisplayName("����� ���� ")]
        public string PageTitle { get; set; }
        [DisplayName("���� ����")]
        public string PageDescription { get; set; }
        [DisplayName("����� ���� -������� �����")]
        public string PageKeywords { get; set; }

        public virtual ICollection<PriceModel> PriceModels { get; set; }
        public virtual ICollection<BackgroundImage> BackgroundImages { get; set; } 
    }
}