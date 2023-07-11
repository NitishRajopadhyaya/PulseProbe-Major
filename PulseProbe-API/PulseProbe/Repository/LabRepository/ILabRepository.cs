using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public interface ILabRepository
    {
        LabModel GetByid(int id);
        LabModel Update(LabModel model);
        LabModel Create(LabModel model);
        List<LabModel> GetAll();
    }
}
