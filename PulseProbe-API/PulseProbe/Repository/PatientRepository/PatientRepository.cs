using PulseProbe.AppDBContext;
using PulseProbe.Model;
using PulseProbe.utility;

namespace PulseProbe.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;
        private readonly IImage _image;
        public PatientRepository(AppDbContext context, IImage image)
        {
            _context = context;
            _image = image;
        }
        public async Task<IResult> CreatePatient(PatientModel model)
        {
            try
            {
                _image.DecodeBase64String(model.PatientImage, "PatientImages", model.PatientFirstName, model.PatientLastName);
                await _context.Patient.AddAsync(model);
                await _context.SaveChangesAsync();
                return Results.Ok("Patient Added");
            }
            catch (Exception ex)
            {
                return Results.Problem(detail:ex.Message,statusCode:500);
            }
            
        }

        public async Task<PatientModel> DeletePatient(int id)
        {
            var patient = await _context.Patient.FindAsync(id);
            if( patient != null ) 
            {
                _context.Patient.Remove(patient);
                _context.SaveChanges();
            }
            return patient;
        }

        public List<PatientModel> GetAllPatient()
        {
            return _context.Patient.ToList();
            
        }

        public  async Task<IResult> GetPatientByid(int id)
        {
            try
            {

                var patient = await _context.Patient.FindAsync(id);
                if (patient == null)
                {
                    return Results.Problem(detail: "Patient Not Found", statusCode: 404);
                }
                patient.PatientImage = _image.encodeToBase64(patient.PatientFirstName, patient.PatientLastName, "PatientImages");
                return Results.Ok(patient);
                
            }
            catch(Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500);
            }
            
        }

        public async Task<IResult> UpdatePatient(PatientModel model)
        {
            try
            {
                var patient = _context.Patient.Update(model);
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
