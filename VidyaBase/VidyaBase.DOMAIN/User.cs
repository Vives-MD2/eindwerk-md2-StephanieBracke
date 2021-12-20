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
        public ICollection<Wishlist> Wishlists { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<UserAchievement> UserAchievements { get; set; }

        public ICollection<OwnedGame> OwnedGames { get; set; }
        // gebruiker heeft 1 collection
        public ICollection<Collection> Collections { get; set; }
        //public int? CollectionID { get; set; }
    }
}
