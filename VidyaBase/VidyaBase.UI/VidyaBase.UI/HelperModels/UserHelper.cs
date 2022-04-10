using System;
using System.Collections.Generic;

namespace VidyaBase.UI.HelperModels
{
    public class UserHelper
    {
        // fill in variables on creation for testing

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Email { get; set; }
    }
}
