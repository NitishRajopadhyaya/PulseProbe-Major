using FluentValidation;
using PulseProbe.Model;

namespace PulseProbe.Validator
{
    public static class ValidatorService
    {
        public static void AddValidatorService(this IServiceCollection ser)
        {
            ser.AddScoped<IValidator<PatientModel>, PatientValidator>();
            ser.AddScoped<IValidator<DoctorModel>, DoctorValidator>();
            ser.AddScoped<IValidator<LabModel>, LabValidator>();
        }
    }
}
