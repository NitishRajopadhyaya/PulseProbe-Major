using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public interface IPatientRepository
    {
        List<PatientModel> GetAllPatient();
        Task<PatientModel> CreatePatient(PatientModel model);
        PatientModel UpdatePatient(int id, PatientModel model);
        Task<PatientModel> DeletePatient(int id);
        PatientModel GetPatientByid(int id);
    }
}
