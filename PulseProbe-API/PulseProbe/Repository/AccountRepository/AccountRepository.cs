using PulseProbe.AppDBContext;
using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AccountRepository> _logger;
        public AccountRepository(AppDbContext context, ILogger<AccountRepository> logger)
        {
          _context = context;
          _logger = logger;
        }
        public async Task<IResult> RegisterAccountAsync(AccountModel model)
        {
            try
            {
                model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
                await _context.UserAccount.AddAsync(model);
                await _context.SaveChangesAsync();
                return Results.Ok("User Created");

            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500);

            }

        }
    }
}
