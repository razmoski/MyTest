﻿using System;

namespace HighfieldTest.Services.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FavouriteColour { get; set; }
    }
}
