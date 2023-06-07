using Assignment.Contracts.DTO;
using FluentValidation;

namespace Assignment.Core.Validators
{
    public class CreateEmployeeDTOValidator : AbstractValidator<CreateEmployeeDTO>
    {
        public CreateEmployeeDTOValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required");
            RuleFor(x => x.Dob).NotEmpty().WithMessage("DOB is required");
            RuleFor(x => x.GenderRefId).NotEmpty().WithMessage("Gender is required");
            RuleFor(x => x.ContactNumber).NotEmpty().WithMessage("Contact Number is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required");
            RuleFor(x => x.State).NotEmpty().WithMessage("State is required");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required");
            RuleFor(x => x.EmployeeNumber).NotEmpty().WithMessage("Employee Number is required");
            RuleFor(x => x.EmpDesignation).NotEmpty().WithMessage("Designation is required");
            RuleFor(x => x.PracticeRefId).NotEmpty().WithMessage("Practice is required");
            RuleFor(x => x.Doj).NotEmpty().WithMessage("DOJ is required");
            RuleFor(x => x.EmpType).NotEmpty().WithMessage("Employee Type is required");
            RuleFor(x => x.Email)  
              .Matches(@"^[a-zA-Z0-9.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$").WithMessage("Please enter a valid email")  
              .NotEmpty();  

            RuleFor(x => x.ContactNumber)  
              .Matches(@"^(((\+){1}91){1})??-?[98765]{1}[0-9]{9}").WithMessage("Please enter a valid contact number")  
              .NotEmpty();  
            RuleFor(x => x.AlternateNumber)  
              .Matches(@"^(((\+){1}91){1})??-?[98765]{1}[0-9]{9}").WithMessage("Please enter a valid alternate number"); 

        }
    }
}
