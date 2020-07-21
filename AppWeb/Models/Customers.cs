using System;
using System.ComponentModel.DataAnnotations;

namespace AppWeb.Models
{
    public class Customers
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Subscribe to Newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        [Min18YearIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}