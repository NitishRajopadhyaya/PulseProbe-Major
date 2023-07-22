
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PulseProbe.Model;
using PulseProbe.Repository;
using System.Runtime.CompilerServices;

namespace EndPoints.PatientEndPoints
{

    public static class PatientEndPoint
    {
        public static void RegisterPatientEndPoints(this WebApplication app)
        {
            
            app.MapGet("Patient/GetAllDetails", Getall);
            app.MapPost("Patient/Add", AddPatientInfo);
            app.MapPut("Patient/update/{id}", Update);
            app.MapGet("Patient/GetById/{id}", GetById);
            //app.MapDelete("/DeletePatient/{id}", deletePatientInfo);
        }
        public static IResult Getall(IPatientRepository _patientRepo)
        {
            var patient = _patientRepo.GetAllPatient();
            return Results.Ok(patient);
        }
        public static async Task<IResult> AddPatientInfo(IPatientRepository _patientRepo, PatientModel model, IValidator<PatientModel> validator)
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
            var patient = await _patientRepo.CreatePatient(model);
            return Results.Ok(patient);
        }
        public static IResult Update(IPatientRepository _patientRepo, PatientModel model, int id)
        {
            var patient = _patientRepo.UpdatePatient(id, model);
            return Results.Ok(patient);
        }
        public static IResult deletePatientInfo(IPatientRepository _patientRepo, int id)
        {
            var patient = _patientRepo.DeletePatient(id);
            return Results.Ok(patient);
        }
        public static IResult GetById(IPatientRepository _patientRepo, int id)
        {
            var patient = _patientRepo.GetPatientByid(id);
            return Results.Ok(patient);
        }

    }
}
