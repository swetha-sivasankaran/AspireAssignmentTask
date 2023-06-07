using Assignment.Contracts.DTO;
using FluentValidation;

namespace Assignment.Core.Validators
{
    public class CreateAppDTOValidator : AbstractValidator<CreateAppDTO>
    {
        public CreateAppDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Provide a brief description about the App");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Developer).NotEmpty().WithMessage("Developer Name is required");
            RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required");
        }
    }
}
