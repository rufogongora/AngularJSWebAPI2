using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lacks2.ViewModels {
    public class PersonViewModel {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<FoodViewModel> Foods { get; set; }
    }
}