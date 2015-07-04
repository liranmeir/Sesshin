using System.Collections.Generic;

namespace Sesshin.Model
{
    public class ThreatmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Therapist> Therapists { get; set; }

        public ThreatmentType()
        {
            Therapists = new HashSet<Therapist>();
        }
    }
}