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
        [DisplayName("�� ����")]
        public string Name { get; set; }
        [Required]
        [DisplayName("�� ���� �������")]
        public string EnglishName { get; set; }

        [DisplayName("����� ���� ")]
        public string PageTitle { get; set; }
        [DisplayName("���� ����")]
        public string PageDescription { get; set; }
        [DisplayName("����� ���� -������� �����")]
        public string PageKeywords { get; set; }


        [DisplayName("�����")]

        public string Headline { get; set; }
        [DisplayName("����")]
        [AllowHtml]
        public string Content { get; set; }
        [DisplayName("�����")]
        public DateTime DateCreated { get; set; }

        public virtual ICollection<BackgroundImage> BackgroundImages { get; set; } 
    }
}