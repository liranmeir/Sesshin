using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sesshin.Model
{
    public class BackgroundImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Article> Articles { get; set; } 
    }
}
