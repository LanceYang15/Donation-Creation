using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonationCreation.Models
{
    public class DonationBoxCreationFormViewModel
    {
        //what is being passed in here?

        //list of Catetories
        public IEnumerable<DonationBoxCategory> DonationBoxCategory { get; set; }

        public DonationBox DonationBox { get; set; }

        public Item Item { get; set; }
    }
}