using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Sesshin.Model
{
    public class Street
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentCityId { get; set; }
    }
}
