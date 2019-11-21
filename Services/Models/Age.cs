using System;

namespace HighfieldTest.Services.Models
{
    public class Age
    {
        public Guid UserId { get; set; }
        public int OriginalAge { get; set; }
        public int AgePlusTwenty { get; set; }
    }
}
