using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sesshin.Model
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("Region")]
        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }

        public virtual ICollection<Therapist> Therapists { get; set; }

        public City()
        {
            Therapists = new HashSet<Therapist>();
        }
    }
}
