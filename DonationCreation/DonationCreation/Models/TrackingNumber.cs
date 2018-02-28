using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonationCreation.Models
{
    public class TrackingNumber
    {
        public int TrackingNumberId { get; set; }

        public string TrackingNumberString { get; set; }

        //Navigation Property to ApplicationUser 
        public ApplicationUser ApplicationUser { get; set; }
        //set the Foreign Key
        public string ApplicationUserId { get; set; }


        public GuestUser GuestUser { get; set; }
        public int GuestuserId { get; set; }
    }
}