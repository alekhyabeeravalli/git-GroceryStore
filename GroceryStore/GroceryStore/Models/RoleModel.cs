using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class RoleModel
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
