using System;
using System.Collections.Generic;

namespace Assignment.Contracts.Data.Entities{
    public partial class EmployeeDetail
    {
        public int EmployeeDetailId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public int GenderRefId { get; set; }
        public string ContactNumber { get; set; } = null!;
        public string AlternateNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string? Zip { get; set; }
        public string EmployeeNumber { get; set; } = null!;
        public string EmpDesignation { get; set; } = null!;
        public int PracticeRefId { get; set; }
        public DateTime Doj { get; set; }
        public string EmpType { get; set; } = null!;

        public virtual ReferenceTbl GenderRef { get; set; } = null!;
        public virtual ReferenceTbl PracticeRef { get; set; } = null!;
    }
}
