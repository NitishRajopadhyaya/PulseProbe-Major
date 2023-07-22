using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public interface ITimeScheduleRepository
    {
       Task<TimeScheduleModel> GetScheduleById(int id);
       Task<IResult> CreateSchedule(TimeScheduleModel model);
       Task<IResult> GetScheduleBydoctorIdandClinicId(int doctorId, int clinicId);
       Task<IResult> UpdateSchedule(TimeScheduleModel model);
    }
}
