using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public interface IEchoDataPredictionRepsoitory
    {
        OutputDataModel EchoDataPredict(InputDataModel model);
    }
}
