using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sesshin.Website.Models
{
    public class LinkBoxModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string SubText { get; set; }
    }

    public class IndexViewModel
    {
        public List<LinkBoxModel> LinkBoxes { get; set; }
    }
}