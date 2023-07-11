using PulseProbe.AppDBContext;
using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public class LabRepository : ILabRepository
    {
        private readonly AppDbContext _context;
        public LabRepository(AppDbContext context)
        {
            _context = context;
        }
        public LabModel Create(LabModel model)
        {
            _context.Lab.Add(model);
            _context.SaveChanges();
            return model;
        }

        public List<LabModel> GetAll()
        {
            return _context.Lab.ToList();
        }

        public LabModel GetByid(int id)
        {
            var lab = _context.Lab.Find(id);
            return lab;
        }

        public LabModel Update(LabModel model)
        {
            var lab = _context.Lab.Attach(model);
            lab.State =Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return model;
        }
    }
}
