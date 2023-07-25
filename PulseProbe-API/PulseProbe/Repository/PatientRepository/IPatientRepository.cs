using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public interface IPatientRepository
    {
        List<PatientModel> GetAllPatient();
        Task<IResult> CreatePatient(PatientModel model);
        Task<IResult> UpdatePatient(PatientModel model);
        Task<PatientModel> DeletePatient(int id);
        Task<IResult> GetPatientByid(int id);
    }
}
