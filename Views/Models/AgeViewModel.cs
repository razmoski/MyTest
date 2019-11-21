using System;

namespace HighfieldTest.Views.Models
{
    public class AgeViewModel
    {
        public Guid UserId { get; set; }
        public int OriginalAge { get; set; }
        public int AgePlusTwenty { get; set; }
    }
}
