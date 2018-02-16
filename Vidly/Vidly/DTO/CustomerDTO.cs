using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models.Validation;

namespace Vidly.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Full Name Required")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedTONewsLetter { get; set; }
        
        public MembershiptypDTO MembershipType { get; set; }

        [Required(ErrorMessage = "Please select a plan")]
        public byte MembershipTypeId { get; set; }

        //[Min18YearsifMember_Customer]
        public DateTime? DateofBirth { get; set; }


    }
}