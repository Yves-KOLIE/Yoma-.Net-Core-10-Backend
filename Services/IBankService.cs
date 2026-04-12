using Microsoft.EntityFrameworkCore;
using YOMA.Models;
using YOMA.Models.Tables;

public interface IBankService
{
    Task<Bank> CreateBankAsync(Bank bank);
    Task<Bank> UpdateBankAsync(Bank bank);
    Task<Bank?> GetBankAsync(int id);
    Task<IEnumerable<Bank>> GetBanksAsync();
    Task<IEnumerable<Bank>> GetBankBatchAsync(int[] ids);
}

public class BankService : IBankService
{
    private readonly Context _context;

    public BankService(Context context)
    {
        _context = context;
    }

    public async Task<Bank> CreateBankAsync(Bank bank)
    {
        _context.Banks.Add(bank);
        await _context.SaveChangesAsync();
        return bank;
    }

    public async Task<Bank> UpdateBankAsync(Bank bank)
    {
        _context.Banks.Update(bank);
        await _context.SaveChangesAsync();
        return bank;
    }

    public async Task<Bank?> GetBankAsync(int id)
    {
        return await _context.Banks.FindAsync(id);
    }

    public async Task<IEnumerable<Bank>> GetBanksAsync()
    {
        return await _context.Banks.ToListAsync();
    }

    public async Task<IEnumerable<Bank>> GetBankBatchAsync(int[] ids)
    {
        return await _context.Banks.Where(b => ids.Contains(b.ID)).ToListAsync();
    }
}