using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public interface IAccountRepository
    {
        Task<IResult> RegisterAccountAsync(AccountModel model);
    }
}
