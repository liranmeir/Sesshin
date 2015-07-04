using System.ComponentModel.DataAnnotations;

namespace Sesshin.Model
{
    public class Redirect
    {
        [Key]
        public int RedirectId { get; set; }
        public string OldFile { get; set; }
        public string NewPath { get; set; }
    }
}
