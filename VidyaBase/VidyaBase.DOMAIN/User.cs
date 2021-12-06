using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{
    public class User : GObject
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        //Gebruiker kan meerdere lijsten hebben
        //public ICollection<UserWishlist> Wishlists { get; set; }
        //public ICollection<UserCollection> Collections { get; set; }
        //public ICollection<UserAchievement> Achievements { get; set; }
    }
}
