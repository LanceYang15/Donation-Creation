using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonationCreation.Models
{
    public class GuestUser
    {
        public int GuestUserId { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string GuestUserEmail { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string GuestUserFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string GuestUserLastName { get; set; }

        [Required]
        [Display(Name = "City")]
        public string GuestUserCity { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string GuestUserZipCode { get; set; }
    }
}