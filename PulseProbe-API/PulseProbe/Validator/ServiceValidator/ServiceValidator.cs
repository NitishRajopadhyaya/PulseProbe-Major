using FluentValidation;
using PulseProbe.Model;

namespace PulseProbe.Validator
{
    public class ServiceValidator:AbstractValidator<ClinicLabServiceModel>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.ServiceName)
                        .NotEmpty()
                        .WithMessage("Service Name is required")
                        .Matches("^[A-Za-z ]+$")
                        .WithMessage("Value should be String only");

        }
    }
}
