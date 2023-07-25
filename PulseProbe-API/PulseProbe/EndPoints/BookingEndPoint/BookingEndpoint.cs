using FluentValidation;
using PulseProbe.Model;
using PulseProbe.Repository;

namespace PulseProbe.EndPoints
{
    public static class BookingEndpoint
    {
        public static void RegisterBookingndPoints(this WebApplication app)
        {
            app.MapPost("Booking/Create", AddBooking);
            app.MapGet("Booking/GetByPatientId/{id}", GetById);
        }
        public static async Task<IResult> AddBooking(IBookingRepository _repo,IValidator<BookingModel> validator,BookingModel model)
        {
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                var Errorlist = new List<string>();
                foreach (var error in validationResult.Errors.ToList())
                {
                    Errorlist.Add(error.PropertyName + ":" + error.ErrorMessage);
                }
                return Results.BadRequest(Errorlist);
            }
            return await _repo.CreateBooking(model);
        }
        public static async Task<IResult> GetById(IBookingRepository _repo,int patientId)
        {
            return  await _repo.GetBookingByPatientId(patientId);
        }
    }
}
