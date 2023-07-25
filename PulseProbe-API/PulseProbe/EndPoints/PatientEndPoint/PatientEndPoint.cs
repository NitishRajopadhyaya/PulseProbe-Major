
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PulseProbe.Model;
using PulseProbe.Repository;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EndPoints.PatientEndPoints
{

    public static class PatientEndPoint
    {
        public static void RegisterPatientEndPoints(this WebApplication app)
        {
            
            app.MapGet("Patient/GetAllDetails", Getall);
            app.MapPost("Patient/Add", AddPatientInfo);
            app.MapPut("Patient/update", Update);
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
            return await _patientRepo.CreatePatient(model);
        }
        public static async Task<IResult> Update(IPatientRepository _patientRepo,IValidator<PatientModel> validator, PatientModel model)
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
            return await _patientRepo.UpdatePatient( model);
        }
        public static IResult deletePatientInfo(IPatientRepository _patientRepo, int id)
        {
            var patient = _patientRepo.DeletePatient(id);
            return Results.Ok(patient);
        }
        public static async Task<IResult> GetById(IPatientRepository _patientRepo, int id)
        {
            return await _patientRepo.GetPatientByid(id);
        }

    }
}
