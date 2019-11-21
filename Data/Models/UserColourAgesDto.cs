using System.Collections.Generic;

namespace HighfieldTest.Data.Models
{
    public class UserColourAgesDto
    {
        public List<UserDto> Users { get; set; }
        public List<AgesDto> Ages { get; set; }
        public List<ColourDto> TopColours { get; set; }
    }
}
