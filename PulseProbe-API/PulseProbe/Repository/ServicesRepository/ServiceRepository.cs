using Microsoft.EntityFrameworkCore;
using PulseProbe.AppDBContext;
using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ServiceRepository> _logger;
        public ServiceRepository(AppDbContext context, ILogger<ServiceRepository> logger)
        {
            _context = context;
            _logger = logger;

        }
        public async Task<IResult> Add(ClinicLabServiceModel model)
        {
            try
            {
                await _context.ServicesProvided.AddAsync(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("-----Service added to Db------");
                return Results.Ok("Service Added");
            }
            catch (Exception ex)
            {
                _logger.LogInformation("----Exception occured--" + ex.Message);
                return Results.Problem(detail:ex.Message,statusCode:500);
            }
        }

        public async Task<IResult> GetAllServices()
        {
            try
            {
               var services =  await _context.ServicesProvided.ToListAsync();
               _logger.LogInformation("----Fetched Services Name from Db-----");
                return Results.Ok(services);
            }
            catch(Exception ex)
            {
                _logger.LogInformation("----Exception occured--" + ex.Message);
                return Results.Problem(detail: ex.Message, statusCode: 500);
            }
        }
    }
}
