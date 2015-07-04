using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Sesshin.Model
{
    public class Customer
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("שם פרטי")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [DisplayName("שם משפחה")]
        public string LastName { get; set; }

        [DisplayName("כתובת")]
        public Address Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsAcceptEmail { get; set; }

        public eLeadSource LeadSource { get; set; }

        [DisplayName("יומולדת")]
        public DateTime?  Birthday { get; set; }

        [DisplayName("יום נישואין")]
        public DateTime? Aniversery { get; set; }

        [DisplayName("תאריך הוספה")]
        public DateTime? CreationDate { get; set; }
    }
}
