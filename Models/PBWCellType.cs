using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTemp1.Models
{
    public class PBWCellType
    {
        [Key]
        public int Id { get; set; } // prop press tab twice

        [Required]
        public string CellTypeName { get; set; }
                
    }
}
