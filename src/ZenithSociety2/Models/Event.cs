using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ZenithSociety2.Models.Custom_Validation;


namespace ZenithSociety2.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        [AfterNow()]
        [Display(Name = "From")]
        public DateTime FromDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        //[GreaterThan("FromDate")] // Note: FoolProof Nuget
        [SameDay("FromDate")]
        [Display(Name = "To")]
        public DateTime ToDate { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }  // For Event (not Activity)


        [Display(Name = "Activity")]
        public int ActivityId { get; set; }

        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }
    }
}
