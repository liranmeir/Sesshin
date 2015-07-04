using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Sesshin.Model
{
    [ComplexType]
    public class Address
    {
        //public int AddressId { get; set; }

        public int? CityId { get; set; }

        [DisplayName("עיר")]
        public string City { get; set; }

        [DisplayName("רחוב")]
        public string Street { get; set; }

        [DisplayName("מספר")]
        public string Number { get; set; }

        [DisplayName("הערות")]
        public string Remarks { get; set; }
    }
}
