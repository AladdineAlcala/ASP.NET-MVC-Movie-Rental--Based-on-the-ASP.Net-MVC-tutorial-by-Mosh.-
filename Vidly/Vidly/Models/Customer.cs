using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models.Validation.Customer_Validation_only;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Full Name Required")]
        [StringLength(255)]
        [Display(Name = "Full Name: ")]
        public string Name { get; set; }

        public bool IsSubscribedTONewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name ="Membership Type")]
        [Required(ErrorMessage ="Please select a plan")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth: ")]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Min18yrsIfMember]
        public DateTime? DateofBirth { get; set; }

    }
}