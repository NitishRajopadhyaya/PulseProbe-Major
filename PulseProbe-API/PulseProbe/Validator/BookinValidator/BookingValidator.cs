using FluentValidation;
using PulseProbe.Model;

namespace PulseProbe.Validator
{
    public class BookingValidator:AbstractValidator<BookingModel>
    {
        public BookingValidator()
        {
            RuleFor(x => x.PatientId)
                .NotEmpty()
                .WithMessage("PatientId  is required");
            RuleFor(x => x.DoctorId)
                .NotEmpty()
                .WithMessage("DoctorId  is required");
            RuleFor(x => x.ClinicId)
                .NotEmpty()
                .WithMessage("ClinicId  is required");
            RuleFor(x => x.Time)
                .NotEmpty()
                .WithMessage("Booking Time is required");
            RuleFor(x => x.BookedDate)
                        .NotEmpty()
                        .WithMessage("Booking date is required");

        }
    }
}
