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
            }
            var doctorVerification = _nMCDoctor.ValidateDoctor(model.FirstName +" "+ model.LastName, model.NMCNumber, model.Degree);
            if(doctorVerification == false)
            {
                return Results.Problem(detail:"Doctor Not Registered in NMC",statusCode:404);
            }
            return await _doctorRepo.Create(model);
        }
        public static async Task<IResult> Update(IDoctorRepository _doctorRepo,IValidator<DoctorModel> validator, DoctorModel model)
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
            return await _doctorRepo.Update(model);
        }
        public static async Task<IResult> GetById(IDoctorRepository _doctorRepo, int id)
        {
            return await _doctorRepo.GetByid(id);
        }
    }
}
