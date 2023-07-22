
namespace PulseProbe.Repository
{
    public static class RepositoryServices
    {
        public static void AddRepositoryService(this IServiceCollection ser)
        {
            ser.AddScoped<IPatientRepository,PatientRepository>();
            ser.AddScoped<IDoctorRepository, DoctorRepository>();
            ser.AddScoped<ILabRepository, LabRepository>();
            ser.AddScoped<ITimeScheduleRepository, TimeScheduleRepository>();
        }
    }
}
     