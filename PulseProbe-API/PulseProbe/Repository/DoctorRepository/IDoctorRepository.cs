using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public interface IDoctorRepository
    {
        DoctorModel GetByid(int id);
        DoctorModel Update(DoctorModel model);
        DoctorModel Create(DoctorModel model);
        List<DoctorModel> GetAll();
    }
}
