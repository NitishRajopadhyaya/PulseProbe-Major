namespace PulseProbe.Repository
{
    public static class RepositoryServices
    {
        public static void AddRepositoryService(this IServiceCollection ser)
        {
            ser.AddScoped<IPatientRepository,PatientRepository>();
            ser.AddScoped<IDoctorRepository, DoctorRepository>();
            ser.AddScoped<IHealthCareCenterRepository, HealthCareCenterRepository>();
            ser.AddScoped<ITimeScheduleRepository, TimeScheduleRepository>();
            ser.AddScoped<IServiceRepository, ServiceRepository>();
            ser.AddScoped<IBookingRepository,BookingRepository>();
        }
    }
}
     