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
            ser.AddScoped<IValidator<HealthCareCenterModel>, HealthCareCenterValidator>();
            ser.AddScoped<IValidator<TimeScheduleModel>, TimeScheduleValidator>();
            ser.AddScoped<IValidator<ClinicLabServiceModel>, ServiceValidator>();
            ser.AddScoped<IValidator<BookingModel>, BookingValidator>();
        }

    }
}
