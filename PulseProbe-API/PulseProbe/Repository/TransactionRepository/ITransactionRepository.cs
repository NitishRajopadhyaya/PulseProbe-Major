using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public interface ITransactionRepository
    {
        Task<IResult> AddTranscationRecord(TransactionModel model);
    }
}
