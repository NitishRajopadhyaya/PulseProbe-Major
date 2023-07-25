using FluentValidation;
using PulseProbe.Model;

namespace PulseProbe.Validator;

public class TimeScheduleValidator:AbstractValidator<TimeScheduleModel>
{
    public TimeScheduleValidator()
    {
        RuleFor(x => x.DoctorId)
                   .NotEmpty()
                   .WithMessage("DoctorId is required");
        RuleFor(x => x.ClinicId)
                    .NotEmpty()
                    .WithMessage("ClinicId is Required");
        RuleFor(x => x.StartingTime)
                    .NotEmpty()
                    .WithMessage("Starting Time must be provided");
        RuleFor(x => x.EndingTime)
                    .NotEmpty()
                    .WithMessage("Ending Time must be provided");



    }
}
