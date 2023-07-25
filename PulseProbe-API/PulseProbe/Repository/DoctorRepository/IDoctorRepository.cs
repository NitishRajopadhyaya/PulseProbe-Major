using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public interface IDoctorRepository
    {
        Task<IResult> GetByid(int id);
        Task<IResult> Update(DoctorModel model);
        Task<IResult> Create(DoctorModel model);
        List<DoctorModel> GetAll();
    }
}
