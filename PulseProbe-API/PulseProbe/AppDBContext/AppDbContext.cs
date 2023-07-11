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
        public DbSet<LabModel> Lab { get; set; }
    }
}
