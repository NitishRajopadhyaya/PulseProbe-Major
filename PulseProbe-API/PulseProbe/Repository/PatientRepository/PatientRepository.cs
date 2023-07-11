using PulseProbe.AppDBContext;
using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;
        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<PatientModel> CreatePatient(PatientModel model)
        {
            await _context.Patient.AddAsync(model);
            _context.SaveChanges();
            return model;
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

        public  PatientModel GetPatientByid(int id)
        {
            var patient =  _context.Patient.Find(id);
            return patient;
        }

        public PatientModel UpdatePatient(int id,PatientModel model)
        {
            var patient = _context.Patient.Attach(model);
            patient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return model;
        }
    }
}
