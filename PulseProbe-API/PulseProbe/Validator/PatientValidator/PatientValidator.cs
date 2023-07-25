using FluentValidation;
using PulseProbe.Model;

namespace PulseProbe.Validator
{
    public class PatientValidator:AbstractValidator<PatientModel>
    {
        public PatientValidator()
        {
            RuleFor(x => x.PatientFirstName)
                        .NotEmpty()
                        .WithMessage("Patient FisrtName is Required")
                        .Matches("^[A-Za-z]+$")
                        .WithMessage("Value should be String only");
            RuleFor(x => x.PatientLastName)
                        .NotEmpty()
                        .WithMessage("Patient LastName is Required")
                        .Matches("^[A-Za-z]+$")
                        .WithMessage("Value should be String only");
            RuleFor(x => x.Age)
                        .NotEmpty()
                        .WithMessage("Age is Required")
                        .LessThanOrEqualTo(100);
            RuleFor(x => x.Gender)
                        .NotEmpty()
                        .WithMessage("Gender is Required")
                        .Matches("^[A-Za-z]+$")
                        .WithMessage("Value should be String only");
            RuleFor(x=>x.Address)
                        .NotEmpty()
                        .WithMessage("Address is Required")
                        .Matches("^[A-Za-z]+$")
                        .WithMessage("Value should be String only");
            RuleFor(x => x.PhoneNumber)
                        .NotEmpty()
                        .WithMessage("Phone Number is Required");
            RuleFor(x => x.Email)
                        .NotEmpty()
                        .WithMessage("Email is Required")
                        .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                        .WithMessage("Email Address Not valid");
            RuleFor(x => x.BirthDate)
                        .NotEmpty()
                        .WithMessage("DOB is required");
            RuleFor(x => x.state)
                        .NotEmpty()
                        .WithMessage("state is Required")
                        .Matches("^[A-Za-z]+$")
                        .WithMessage("Value should be String only");
            RuleFor(x => x.District)
                        .NotEmpty()
                        .WithMessage("District is Required")
                        .Matches("^[A-Za-z]+$")
                        .WithMessage("Value should be String only");
            RuleFor(x => x.Municiplaity)
                        .NotEmpty()
                        .WithMessage("Municiplaity name is Required")
                        .Matches("^[A-Za-z]+$")
                        .WithMessage("Value should be String only");
            RuleFor(x => x.WardNo)
                        .NotEmpty()
                        .WithMessage("WardNo is Required");
                        







        }
    }
}
