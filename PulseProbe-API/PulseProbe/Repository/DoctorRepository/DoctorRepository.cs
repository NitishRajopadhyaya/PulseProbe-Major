using PulseProbe.AppDBContext;
using PulseProbe.Model;
using PulseProbe.utility;

namespace PulseProbe.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;
        private readonly IImage _image;
        public DoctorRepository(AppDbContext context, IImage image)
        {
            _context = context;
            _image = image;
        }

        public async Task<IResult> Create(DoctorModel model)
        {
            try
            {
                _image.DecodeBase64String(model.DoctorImage, "DoctorImages", model.FirstName, model.LastName);
                await _context.Doctor.AddAsync(model);
                await _context.SaveChangesAsync();
                return Results.Ok(model);
            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500);
            }
            
        }

        public List<DoctorModel> GetAll()
        {
            return _context.Doctor.ToList();
        }

        public async Task<IResult> GetByid(int id)
        {
            try
            {
                var doc = await _context.Doctor.FindAsync(id);
                if(doc == null)
                {
                    return Results.Problem(detail: "Doctor Not Registered", statusCode: 404);
                }
                doc.DoctorImage =_image.encodeToBase64(doc.FirstName, doc.LastName, "DoctorImages");
                return Results.Ok(doc);
            }

            catch(Exception ex)
            {
                return Results.Problem(detail:ex.Message,statusCode:500);
            }
        }

        public  async Task<IResult> Update(DoctorModel model)
        {
            try
            {
                var doc = _context.Doctor.Update(model);
                await _context.SaveChangesAsync();
                return Results.Ok("Information Updated");
            }
            catch(Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500);
            }
            
        }
       
    }
}
