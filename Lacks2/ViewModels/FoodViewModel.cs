using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lacks2.ViewModels {
    public class FoodViewModel {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Order { get; set; }
        public int PersonId { get; set; }
        
    }
}