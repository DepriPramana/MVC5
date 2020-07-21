using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AppWeb.Models;

namespace AppWeb.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Subscribe to Newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }
        
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthdate { get; set; }

        public string Title => Id != 0 ? "Edit Customer" : "New Customer";

        public CustomerFormViewModel(Customers customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            Birthdate = customer.Birthdate;
            MembershipTypeId = customer.MembershipTypeId;
        }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

    }
}