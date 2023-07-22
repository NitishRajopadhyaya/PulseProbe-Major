using EndPoints.PatientEndPoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PulseProbe.AppDBContext;
using PulseProbe.EndPoints.DoctorEndPoint;
using PulseProbe.EndPoints.LabEndPoint;
using PulseProbe.EndPoints.TimeScheduleEndPoint;
using PulseProbe.Model;
using PulseProbe.Repository;
using PulseProbe.Validator;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
                 .ReadFrom.Configuration(builder.Configuration)
                 .Enrich.FromLogContext()
                 .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
var connectionString = builder.Configuration.GetConnectionString("Dbstring");
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<AppDbContext>(
                    options => options.UseSqlServer(connectionString)
                    );

builder.Services.AddRepositoryService();
builder.Services.AddValidatorService();
builder.Services.AddScoped<INMCDoctor, NMCDoctor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

PatientEndPoint.RegisterPatientEndPoints(app);
DoctorEndPoint.RegisterDoctorEndPoints(app);
LabEndPoint.RegisterLabEndPoints(app);
TimeScheduleEndPoint.RegisterTimeScheduleEndPoint(app);
//app.MapGet("/getDoctorFromNMCSite", (ISeleniumTests test) =>
//{
//    return Results.Ok(test.ValidateTheMessageIsDisplayed());
//});



app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}