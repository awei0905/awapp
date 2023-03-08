using System;
using System.Collections.Generic;

namespace awapp.Data
{
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public char? Gender { get; set; }
        public DateOnly? Birthdate { get; set; }
        public string? EmailId { get; set; }
        public string? CountryOfBirth { get; set; }
    }
}
