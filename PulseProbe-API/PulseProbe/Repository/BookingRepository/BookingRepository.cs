using Microsoft.EntityFrameworkCore;
using PulseProbe.AppDBContext;
using PulseProbe.Model;
using PulseProbe.Repository;

namespace PulseProbe.Repository
{
    public class BookingRepository : IBookingRepository
    {
        public readonly AppDbContext _context;
        public readonly ILogger<BookingRepository> _logger;
        public BookingRepository(AppDbContext context, ILogger<BookingRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IResult> CreateBooking(BookingModel model)
        {
            try
            {
                var patient = _context.Patient.Find(model.PatientId);
                if (patient == null)
                    return Results.Problem(detail: "Patient not found", statusCode: 404);
                var doctor = _context.Doctor.Find(model.DoctorId);
                if (doctor == null)
                    return Results.Problem(detail: "doctor not found", statusCode: 404);
                var clinic = _context.HealthcareCenter.Find(model.ClinicId);
                if (clinic == null)
                    return Results.Problem(detail: "clinic not found", statusCode: 404);
                model.Patient = patient;
                model.Doctor = doctor;
                model.Clinic = clinic;
                await _context.Booking.AddAsync(model);
                await _context.SaveChangesAsync();
                return Results.Ok("Appointment Booked");
            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500);
            }
        }

        public async Task<IResult> GetBookingByPatientId(int id)
        {
            try
            {
                var bookingtime = await _context.Booking.Where(x => x.PatientId == id).FirstOrDefaultAsync();
                if (bookingtime == null)
                    return Results.Problem(detail: "Booking not found", statusCode: 404);
                return Results.Ok(bookingtime);
            }
            catch(Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500);
            }
        }
    }
}
