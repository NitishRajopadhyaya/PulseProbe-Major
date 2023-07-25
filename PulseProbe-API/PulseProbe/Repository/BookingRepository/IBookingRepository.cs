using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public interface IBookingRepository
    {
        Task<IResult> CreateBooking(BookingModel model);
        Task<IResult> GetBookingByPatientId(int id);
    }
}
