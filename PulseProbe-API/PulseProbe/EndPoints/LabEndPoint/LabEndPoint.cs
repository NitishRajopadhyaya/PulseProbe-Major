using FluentValidation;
using PulseProbe.Model;
using PulseProbe.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PulseProbe.EndPoints.LabEndPoint
{
    public static class LabEndPoint
    {
        public static void RegisterLabEndPoints(this WebApplication app)
        {
            app.MapGet("Lab/GetAllDetails", Getall);
            app.MapPost("Lab/Add", AddLabInfo);
            app.MapPut("Lab/update", Update);
            app.MapGet("Lab/GetById/{id}", GetById);
            //app.MapDelete("/DeletePatient/{id}", deletePatientInfo);
        }
        public static IResult Getall(ILabRepository _labRepo)
        {
            var patient = _labRepo.GetAll();
            return Results.Ok(patient);
        }
        public static async Task<IResult> AddLabInfo(ILabRepository _labRepo, LabModel model, IValidator<LabModel> validator)
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
            var patient = _labRepo.Create(model);
            return Results.Ok(patient);
        }
        public static IResult Update(ILabRepository _labRepo, LabModel model)
        {
            var patient = _labRepo.Update(model);
            return Results.Ok(patient);
        }
        public static IResult GetById(ILabRepository _labRepo, int id)
        {
            var patient = _labRepo.GetByid(id);
            return Results.Ok(patient);
        }
    }
}
