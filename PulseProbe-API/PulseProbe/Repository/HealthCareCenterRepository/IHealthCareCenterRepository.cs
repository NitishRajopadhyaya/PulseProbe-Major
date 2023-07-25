using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public interface IHealthCareCenterRepository
    { 
        Task<IResult> GetByid(int id);
        Task<IResult> Update(HealthCareCenterModel model);
        Task<IResult> Create(HealthCareCenterModel model);
        List<HealthCareCenterModel> GetAll();
        Task<IResult> GetSpecificHealthCareList(string type);
    }
}
