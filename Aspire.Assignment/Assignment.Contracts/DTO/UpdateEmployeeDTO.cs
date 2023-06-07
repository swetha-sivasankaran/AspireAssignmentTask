namespace Assignment.Contracts.DTO
{
    public class UpdateEmployeeDTO
    {
        public int EmployeeDetailId { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public DateTime Dob { get; set; }
        public int GenderRefId { get; set; }
        public string ContactNumber { get; set; } 
        public string? AlternateNumber { get; set; }
        public string Email { get; set; } 
        public string Address { get; set; } 
        public string City { get; set; } 
        public string State { get; set; } 
        public string Country { get; set; } 
        public string? Zip { get; set; }
        public string EmployeeNumber { get; set; } 
        public string EmpDesignation { get; set; } 
        public int PracticeRefId { get; set; }
        public DateTime Doj { get; set; }
        public string EmpType { get; set; } 
    }
}