using Microsoft.EntityFrameworkCore;
using PulseProbe.AppDBContext;
using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public class ServicePriceSetupRepository : IServicePriceSetupReposiory
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ServicePriceSetupRepository> _logger;
        public ServicePriceSetupRepository(AppDbContext context, ILogger<ServicePriceSetupRepository> logger)
        {
            _context = context;
            _logger = logger;

        }
        public async Task<IResult> AddPrice(List<ClinicLabServicesPriceModel> ServicesPriceList)
        {
            try
            {
                await _context.ClinicLabServicesPrice.AddRangeAsync(ServicesPriceList);
                await _context.SaveChangesAsync();
                return Results.Ok("Price Added");
            }
            catch(Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500);
            }

        }

        public async Task<IResult> GetAllServicesOfclinic(int clinicId)
        {
            try
            {
                var services = await _context.ClinicLabServicesPrice.Where(x => x.ClinicId == clinicId).ToListAsync();
                return Results.Ok(services);
            }
            catch(Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500);

            }

        }

        public async Task<IResult> UpdatePrice(List<ClinicLabServicesPriceModel> ServicesPriceList)
        {
            try
            {
                _context.ClinicLabServicesPrice.UpdateRange(ServicesPriceList);
                await _context.SaveChangesAsync();
                return Results.Ok("Changes Updated");
            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500);
            }

        }
    }
}
