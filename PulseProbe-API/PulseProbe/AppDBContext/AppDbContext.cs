using Microsoft.EntityFrameworkCore;
using PulseProbe.Model;

namespace PulseProbe.AppDBContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           :base(options)
        {
            
        }
        public DbSet<PatientModel> Patient { get; set; }
        public DbSet<DoctorModel> Doctor { get; set; }
        public DbSet<HealthCareCenterModel> HealthcareCenter { get; set; }
        public  DbSet<TimeScheduleModel> TimeSchedule { get; set; }
        public DbSet<ClinicLabServiceModel> ServicesProvided { get; set; }
        public DbSet<BookingModel> Booking { get; set; }
    }
}
