using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace Sesshin.Models
{
    public class Contact
    {
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Remarks { get; set; }
        public bool IsAcceptMail { get; set; }
        public bool IsRequestMobile { get; set; }

        public string ToEmailText()
        {
            var retText = new StringBuilder();

            retText.Append("גולש השאיר פרטים באתר").AppendLine();
            retText.Append(IsRequestMobile? "לקוח גולש במובייל":"לקוח גולש בדסקטופ").AppendLine();
            retText.AppendFormat("תאריך :{0}", DateTime.Now).AppendLine();
            retText.AppendFormat("שם :{0}", Name).AppendLine();
            retText.AppendFormat("טלפון :{0}", Phone).AppendLine();
            retText.AppendFormat("הערות :{0}", Remarks).AppendLine(); ;
            retText.AppendFormat("מייל :{0}", Email).AppendLine();
            retText.AppendFormat("מעוניין לקבל מיילים :{0}", IsAcceptMail? "כן":"לא").AppendLine();

            return retText.ToString();
        }
    }
}