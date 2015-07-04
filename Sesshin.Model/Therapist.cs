using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Sesshin.Model
{
    public class Therapist
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        [DisplayName("עיר")]
        public virtual City City { get; set; }

        [DisplayName("קליניקה")]
        public string Clinic { get; set; }

        public virtual ICollection<ThreatmentType> ThreatmentTypes { get; set; }

        public Therapist()
        {
                ThreatmentTypes = new HashSet<ThreatmentType>();
        }
    }
}
