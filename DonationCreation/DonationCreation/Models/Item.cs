using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonationCreation.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int? ItemQuantity { get; set; }

        public string ItemDescription { get; set; }

        //Navigation property
        public DonationBox DonationBox { get; set; }
        //Foreign key
        public int DonationBoxId { get; set; }
    }
}