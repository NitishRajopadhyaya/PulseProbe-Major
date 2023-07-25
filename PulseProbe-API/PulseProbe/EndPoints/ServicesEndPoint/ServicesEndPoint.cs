using FluentValidation;
using PulseProbe.Model;
using PulseProbe.Repository;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PulseProbe.EndPoints.Services
{
    public static class ServicesEndPoint
    {
        public static void RegisterServicesEndPoints(this WebApplication app)
        {

            app.MapGet("Services/GetAllServices", GetallService);
            app.MapPost("Services/Add", Add);
            
        }
        public static async  Task<IResult> GetallService(IServiceRepository _repo)
        {
            return await _repo.GetAllServices();
        }
        public static async Task<IResult> Add(IServiceRepository _repo ,IValidator<ClinicLabServiceModel> validator, ClinicLabServiceModel model)
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
            return await _repo.Add(model);
        }

    }
}
