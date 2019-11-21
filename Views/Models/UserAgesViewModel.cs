using System;

namespace HighfieldTest.Views.Models
{
    public class UserAgesViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FavouriteColour { get; set; }
        public int OriginalAge { get; set; }
        public int AgePlusTwenty { get; set; }
    }
}
