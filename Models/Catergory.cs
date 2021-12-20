using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTemp1.Models
{
    public class Catergory
    {
        [Key]
        public int Id { get; set; } // prop press tab twice
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Display Order for catergory must be greater than 0")]

        public int DisplayOrder { get; set; }
    }
}
