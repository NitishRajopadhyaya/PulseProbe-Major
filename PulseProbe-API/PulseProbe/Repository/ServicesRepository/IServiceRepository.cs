using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public interface IServiceRepository
    {
        Task<IResult> GetAllServices();
        Task<IResult> Add(ClinicLabServiceModel model);

    }
}
