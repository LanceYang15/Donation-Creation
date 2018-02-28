using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonationCreation.Models
{
    public class DonationBox
    {
        public int DonationBoxId { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string DonationBoxTitle { get; set; }

        [Required]
        public string DonationBoxStoryDescription { get; set; }

        public string DonationBoxImage { get; set; }

        public string DonationBoxImageToEdit { get; set; }

        public string DonationBoxItemDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Required]
        public DateTime DonationBoxCreatedDate { get; set; }

        //Navigation Property to ApplicationUser 
        public ApplicationUser ApplicationUser { get; set; }
        //set the Foreign Key
        public string ApplicationUserId { get; set; }

        //Navigation Property to Category
        public DonationBoxCategory DonationBoxCategory { get; set; }
        public int DonationBoxCategoryId { get; set; }

        //setting one to many with item class
        public List<Item> Items { get; set; }
    }
}