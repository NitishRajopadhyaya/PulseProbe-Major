using Microsoft.EntityFrameworkCore;
using PulseProbe.AppDBContext;
using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public class TimeScheduleRepository : ITimeScheduleRepository
    {
        private readonly ILogger<TimeScheduleRepository> _logger;
        private readonly AppDbContext _context;
        public TimeScheduleRepository(ILogger<TimeScheduleRepository> logger,AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<TimeScheduleModel> GetScheduleById(int id)
        {
            var schedule = await _context.TimeSchedule.FindAsync(id);
            return schedule;
        }
        public async Task<IResult> CreateSchedule(TimeScheduleModel model)
        {
            try
            {
                var doctor = await _context.Doctor.FindAsync(model.DoctorId);
                if(doctor== null)
                {
                    return  Results.Problem(detail: "DoctorId is invalid", statusCode: 404);
                }
                model.Doctor = doctor;
                await _context.TimeSchedule.AddAsync(model);
                await _context.SaveChangesAsync();
                return Results.Ok("SuccessFull Added");
            }
            catch(Exception ex)
            {
                return Results.Problem(detail:ex.Message,statusCode:500);
            }
        }
        public  async Task<IResult> GetScheduleBydoctorIdandClinicId(int doctorId, int clinicId)
        {
            try
            {
                var schedule = await _context.TimeSchedule.Where(sch => sch.DoctorId == doctorId &&
                                                                        sch.ClinicId == clinicId).FirstOrDefaultAsync();
                if(schedule== null)
                {
                    return Results.NotFound("No Schedule detected");
                }
                return Results.Ok(schedule);
            }
            catch(Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500);
            }
        }
        public async Task<IResult> UpdateSchedule(TimeScheduleModel model)
        {
            try
            {
                model.Doctor = null;
                var schedule = _context.TimeSchedule.Update(model);
                //schedule.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return Results.Ok("Information Udpated");  

            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500,type:ex.InnerException.ToString());
            }

        }
    }
}
