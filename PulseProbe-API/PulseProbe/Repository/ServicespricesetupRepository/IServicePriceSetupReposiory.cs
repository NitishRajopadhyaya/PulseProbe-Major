using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public interface IServicePriceSetupReposiory
    {
       Task<IResult> AddPrice(List<ClinicLabServicesPriceModel> ServicesPriceList);
       Task<IResult> UpdatePrice(List<ClinicLabServicesPriceModel> ServicesPriceList);
       Task<IResult> GetAllServicesOfclinic(int clinicId);
    }
}
