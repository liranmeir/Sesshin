using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sesshin.Model;
using Sesshin.Service;

namespace Sesshin.Admin.Models
{
    public class BackgroundImageVM
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<BackgroundImage> AvailableImages;
        public List<BackgroundImage> SelectedImages;
    }
}