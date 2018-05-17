using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lacks2.Models {
    public class Food {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Order { get; set; }
        public Person Person { get; set; }
    }
}