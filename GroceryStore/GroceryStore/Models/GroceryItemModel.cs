using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class GroceryItemModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        [NotMapped]
        public string Category { get; set; }
    }
}
