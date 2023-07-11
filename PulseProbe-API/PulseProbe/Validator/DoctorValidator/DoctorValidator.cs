using FluentValidation;
using PulseProbe.Model;

namespace PulseProbe.Validator
{
    public class DoctorValidator:AbstractValidator<DoctorModel>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.FirstName)
                        .NotEmpty()
                        .WithMessage("Doctor FisrtName is Required")
                        .Matches("^[A-Za-z]+$")
                        .WithMessage("Value should be String only");
            RuleFor(x => x.LastName)
                        .NotEmpty()
                        .WithMessage("Doctor LastName is Required")
                        .Matches("^[A-Za-z]+$")
                        .WithMessage("Value should be String only");
            RuleFor(x => x.NMCNumber)
                        .NotEmpty()
                        .WithMessage("License Number is required");
            //RuleFor(x => x.Certificate)
            //            .NotEmpty()
            //            .WithMessage("Certificate for Confirmation is Required");
            RuleFor(x => x.Email)
                        .NotEmpty()
                        .WithMessage("Email is Required")
                        .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                        .WithMessage("Email Address Not valid");
            RuleFor(x => x.Degree)
                        .NotEmpty()
                        .WithMessage("Degree Must Not Be Null");
            RuleFor(x=>x.PhoneNumber)
                        .NotEmpty()
                        .WithMessage("Phone Number is Required");
            RuleFor(x => x.Speciality)
                        .NotEmpty()
                        .WithMessage("Speciality cannot be null");
            RuleFor(x => x.Qualification)
                        .NotEmpty()
                        .WithMessage("Qulification is required");
            RuleFor(x => x.Gender)
                        .NotEmpty()
                        .WithMessage("Gender is Required");
            RuleFor(x => x.Description)
                        .NotEmpty()
                        .WithMessage("Description is required");

        }
    }
}
