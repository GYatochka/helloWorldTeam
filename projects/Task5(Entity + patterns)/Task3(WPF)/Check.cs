using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Task3_WPF_
{/// <summary>
/// клас моделі "чек"
/// </summary>
      [Table("Checks")]
    public class Check
    {
        [Key]
        public int Id { get; set; }
        [Required]
public string Cashier { get; set; }
        [Required]
       public string Details { get; set; }
        [Required]
     public   float Sum { get; set; }
    }
}
