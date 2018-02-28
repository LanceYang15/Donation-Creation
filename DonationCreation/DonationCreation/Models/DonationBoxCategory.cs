using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonationCreation.Models
{
    public class DonationBoxCategory
    {
        public int DonationBoxCategoryId { get; set; }

        [Required]
        [Display(Name ="Category")]
        public string DonationBoxCateogryName { get; set; }
    }
}