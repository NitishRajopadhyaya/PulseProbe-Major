using FluentValidation;
using PulseProbe.Model;

namespace PulseProbe.Validator
{
    public class LabValidator:AbstractValidator<LabModel>
    {
        public LabValidator()
        {
            RuleFor(x => x.LabName)
                       .NotEmpty()
                       .WithMessage("LabName is Required")
                       .Matches("^[A-Za-z ]+$")
                       .WithMessage("Value should be String only");
        }
    }
}
