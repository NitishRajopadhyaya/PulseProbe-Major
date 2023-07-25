using FluentValidation;
using PulseProbe.Model;
using PulseProbe.Repository;
using System.ComponentModel.DataAnnotations;

namespace PulseProbe.EndPoints.TimeScheduleEndPoint
{
    public static  class TimeScheduleEndPoint
    {
        public static void RegisterTimeScheduleEndPoint(this WebApplication app)
        {
            app.MapGet("/TimeSchedule/GetById/{id}", GetTimeScheduleBydId);
            app.MapPost("/TimeSchedule/CreateSchedule", CreateTimeSchedule);
            app.MapPut("/TimeSchedule/UpdateSchedule", UpdateSchedule);
            app.MapGet("/TimeSchedule/GetSpecific/Doctor/{doctorId}/Clinic/{clinicId}", GetScheduleBydoctorIdandClinicId);
        }

        public  async static Task<IResult> GetTimeScheduleBydId(ITimeScheduleRepository _repo, int id)
        {
             var schedule= await _repo.GetScheduleById(id);

            return Results.Ok(schedule);
        }
        public static async Task<IResult> CreateTimeSchedule(ITimeScheduleRepository _repo, TimeScheduleModel model,IValidator<TimeScheduleModel> validator)
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
            return await _repo.CreateSchedule(model);
        }
        public static async Task<IResult> GetScheduleBydoctorIdandClinicId(ITimeScheduleRepository _repo, int doctorId,int clinciId)
        {
            return await _repo.GetScheduleBydoctorIdandClinicId(doctorId, clinciId);
        }
        public static async Task<IResult> UpdateSchedule(ITimeScheduleRepository _repo,IValidator<TimeScheduleModel> validator, TimeScheduleModel model)
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
            return await _repo.UpdateSchedule(model);
        }
    }
}
