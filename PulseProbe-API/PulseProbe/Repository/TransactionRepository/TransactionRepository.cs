using PulseProbe.AppDBContext;
using PulseProbe.Model;

namespace PulseProbe.Repository
{ 
    public class TransactionRepository:ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> AddTranscationRecord(TransactionModel model)
        {
            await _context.Transaction.AddAsync(model);
            await _context.SaveChangesAsync();
            return Results.Ok("Transaction added");
        }
    }
}
