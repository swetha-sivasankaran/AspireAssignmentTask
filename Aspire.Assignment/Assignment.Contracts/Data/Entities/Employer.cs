using System;
using System.Collections.Generic;

namespace Assignment.Contracts.Data.Entities{
    public partial class Employer
    {
        public int EmployerId { get; set; }
        public string TypeOfBusiness { get; set; } = null!;
        public string EmployerEmailId { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Zip { get; set; } = null!;
    }
}
