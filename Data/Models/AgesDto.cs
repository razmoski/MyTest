using System;

namespace HighfieldTest.Data.Models
{
    public class AgesDto
    {
        public Guid UserId { get; set; }
        public int OriginalAge { get; set; }
        public int AgePlusTwenty { get; set; }
    }
}
