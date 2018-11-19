using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesMvc.Models
{
    public class Phone
    {
        public int ID { get; set; }
        public string Owner { get; set; }
        public string Sim { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        [Display(Name = "Screen Size")]
        public float ScreenSize { get; set; }
    }
}

