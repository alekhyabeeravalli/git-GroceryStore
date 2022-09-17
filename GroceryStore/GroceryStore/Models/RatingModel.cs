using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class RatingModel
    {
        [Key]
        public int Id{ get; set; }
        public string GroceryName { get; set; }

        public string RatingScale { get; set; }
        
    }
}
