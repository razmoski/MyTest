using System.Collections.Generic;

namespace HighfieldTest.Views.Models
{
    public class UserColourAgesViewModel
    {
        public List<UsersViewModel> Users { get; set; }
        public List<AgeViewModel> Ages { get; set; }
        public List<ColourViewModel> TopColours { get; set; }
    }
}
