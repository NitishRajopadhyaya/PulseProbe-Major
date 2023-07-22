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
            RuleFor(x => x.Address)
                        .NotEmpty()
                        .WithMessage("Address must be provided")
                        .Matches("^[A-Za-z ]+$")
                        .WithMessage("Value should be String only");
            RuleFor(x=>x.PhoneNumber)
                        .NotEmpty()
                        .WithMessage("Phone Number is Required");
            RuleFor(x => x.Email)
                        .NotEmpty()
                        .WithMessage("Email must be provided")
                        .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                        .WithMessage("Email Address Not valid");
            RuleFor(x => x.Description)
                        .NotEmpty()
                        .WithMessage("Description must be provided");
            RuleFor(x=>x.District)
                        .NotEmpty()
                        .WithMessage("District is Required")
                        .Matches("^[A-Za-z ]+$")
                        .WithMessage("Value should be String only");
            RuleFor(x => x.Province)
                        .NotEmpty()
                        .WithMessage("Province is Required");
            RuleFor(x => x.Image)
                        .NotEmpty()
                        .WithMessage("Image must be provided");
            RuleFor(x=>x.LicsenceNumber)
                        .NotEmpty()
                        .WithMessage("LicsenceNumber must be provided");


        }
    }
}
