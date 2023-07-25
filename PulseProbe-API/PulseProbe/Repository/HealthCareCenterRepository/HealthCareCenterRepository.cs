using Microsoft.EntityFrameworkCore;
using PulseProbe.AppDBContext;
using PulseProbe.Model;
using PulseProbe.utility;

namespace PulseProbe.Repository
{
    public class HealthCareCenterRepository : IHealthCareCenterRepository
    {
        private readonly AppDbContext _context;
        private readonly IImage _image;
        public HealthCareCenterRepository(AppDbContext context,IImage image)
        {
            _context = context;
            _image = image;
        }
        public async Task<IResult> Create(HealthCareCenterModel model)
        {
            try
            {
                _image.DecodeBase64String(model.HealthCenterImage, "HealthCareCenterImages", model.HealthCareCenterName, model.Address);
                await _context.HealthcareCenter.AddAsync(model);
                await _context.SaveChangesAsync();
                return Results.Ok("Information Added");
            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500);
            }
            
        }

        public List<HealthCareCenterModel> GetAll()
        {
            return _context.HealthcareCenter.ToList();

        }

        public async Task<IResult> GetByid(int id)
        {
            try
            {
                var healthcareCenter = await _context.HealthcareCenter.FindAsync(id);
                if (healthcareCenter == null)
                {
                    return Results.Problem(detail: "Lab not found", statusCode: 404);
                }
                healthcareCenter.HealthCenterImage = _image.encodeToBase64(healthcareCenter.HealthCareCenterName, healthcareCenter.Address, "HealthCareCenterImages");
                return Results.Ok(healthcareCenter);
            }
            catch(Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500);

            }

        }

        public async Task<IResult> Update(HealthCareCenterModel model)
        {
            try
            {
                var lab = _context.HealthcareCenter.Update(model);
                await _context.SaveChangesAsync();

                return Results.Ok("Information updated");
            }
            catch(Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500);

            }

        }
        public async Task<IResult> GetSpecificHealthCareList(string type)
        {
            try
            {
                var list = await _context.HealthcareCenter.Where(x=>x.Type == type).ToListAsync();
                if (list.Count == 0)
                {
                   return Results.Problem(detail: type + " Not Found", statusCode: 404);
                }
                foreach (var item in list)
                {
                    item.HealthCenterImage = _image.encodeToBase64(item.HealthCareCenterName, item.Address, "HealthCareCenterImages");
                }
                return Results.Ok(list);
            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500);
            }
        }
    }
}
