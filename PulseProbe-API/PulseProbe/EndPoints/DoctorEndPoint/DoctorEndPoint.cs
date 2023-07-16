using FluentValidation;
using PulseProbe.Model;
using PulseProbe.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PulseProbe.EndPoints.DoctorEndPoint
{
    public static class DoctorEndPoint
    {
        public static void RegisterDoctorEndPoints(this WebApplication app)
        {
            app.MapGet("Doctor/GetAllDetails", Getall);
            app.MapPost("Doctor/Add", AddDoctorInfo);
            app.MapPut("Doctor/update", Update);
            app.MapGet("Doctor/GetById/{id}", GetById);
            //app.MapDelete("/DeletePatient/{id}", deletePatientInfo);
        }
        public static IResult Getall(IDoctorRepository _doctorRepo)
        {
            var patient = _doctorRepo.GetAll();
            return Results.Ok(patient);
        }
        public static async Task<IResult> AddDoctorInfo(IDoctorRepository _doctorRepo,INMCDoctor _nMCDoctor, DoctorModel model, IValidator<DoctorModel> validator)
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
                //return Results.BadRequest(validationResult.Errors.ToList());
            }
            var doctorVerification = _nMCDoctor.ValidateDoctor(model.FirstName +" "+ model.LastName, model.NMCNumber, model.Degree);
            if(doctorVerification == false)
            {
                return Results.BadRequest("Doctor Not Redistered in NMC");
            }
            var patient = _doctorRepo.Create(model);
            return Results.Ok(patient);
        }
        public static IResult Update(IDoctorRepository _doctorRepo, DoctorModel model)
        {
            var patient = _doctorRepo.Update(model);
            return Results.Ok(patient);
        }
        public static IResult GetById(IDoctorRepository _doctorRepo, int id)
        {
            var patient = _doctorRepo.GetByid(id);
            return Results.Ok(patient);
        }
    }
}
