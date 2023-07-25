using FluentValidation;
using PulseProbe.Model;
using PulseProbe.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PulseProbe.EndPoints.HealthCareCenterEndPoint
{
    public static class HealthCareCenterEndPoint
    {
        public static void RegisterLabEndPoints(this WebApplication app)
        {
            app.MapGet("HealthCareCenter/GetAllDetails", Getall);
            app.MapPost("HealthCareCenter/Add", AddLabInfo);
            app.MapPut("HealthCareCenter/update", Update);
            app.MapGet("HealthCareCenter/GetById/{id}", GetById);
            app.MapGet("HealthCareCenter/GetClinicList/{type}", GetSpecificHealthCareList);
            app.MapGet("HealthCareCenter/GetLabList/{type}", GetSpecificHealthCareList);

            //app.MapDelete("/DeletePatient/{id}", deletePatientInfo);
        }
        public static IResult Getall(IHealthCareCenterRepository _repo)
        {
            var patient = _repo.GetAll();
            return Results.Ok(patient);
        }
        public static async Task<IResult> AddLabInfo(IHealthCareCenterRepository _repo, HealthCareCenterModel model, IValidator<HealthCareCenterModel> validator)
        {
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                var Errorlist = new List<string>();
                foreach(var error in validationResult.Errors.ToList())
                {
                    Errorlist.Add(error.PropertyName + ":" + error.ErrorMessage);
                }

                //return Results.BadRequest(validationResult.Errors.ToList());
                return Results.BadRequest(Errorlist);
            }
            return await _repo.Create(model);
        }
        public static  async Task<IResult> Update(IHealthCareCenterRepository _repo, IValidator<HealthCareCenterModel> validator, HealthCareCenterModel model)
        {
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                var Errorlist = new List<string>();
                foreach (var error in validationResult.Errors.ToList())
                {
                    Errorlist.Add(error.PropertyName + ":" + error.ErrorMessage);
                }

                //return Results.BadRequest(validationResult.Errors.ToList());
                return Results.BadRequest(Errorlist);
            }
            return await _repo.Update(model);
        }
        public static async Task<IResult> GetById(IHealthCareCenterRepository _repo, int id)
        {
            return await _repo.GetByid(id);
        }
        public static async Task<IResult> GetSpecificHealthCareList(IHealthCareCenterRepository _repo,string type)
        {
            return await _repo.GetSpecificHealthCareList(type);
        }
    }
}
