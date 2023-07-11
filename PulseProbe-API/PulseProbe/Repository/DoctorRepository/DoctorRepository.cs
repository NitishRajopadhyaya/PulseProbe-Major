using PulseProbe.AppDBContext;
using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;
        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public DoctorModel Create(DoctorModel model)
        {
            _context.Doctor.Add(model);
            _context.SaveChanges();
            return model;
        }

        public List<DoctorModel> GetAll()
        {
            return _context.Doctor.ToList();
        }

        public DoctorModel GetByid(int id)
        {
            var doc = _context.Doctor.Find(id);
            return doc;
        }

        public DoctorModel Update(DoctorModel model)
        {
            var doc = _context.Doctor.Attach(model);
            doc.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return model;
        }
    }
}
