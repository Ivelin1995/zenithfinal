using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithSociety2.Models
{
    public class Activity
    {
        [Key]
        
        public int ActivityId { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string ActivityDescription { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]   
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm}")]    
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
    }
}
