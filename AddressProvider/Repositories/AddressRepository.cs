using AddressProvider.Data.Contexts;
using AddressProvider.Data.Entities;
using AddressProvider.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AddressProvider.Repositories;
public class AddressRepository(Context context) : IAddressRepository
{
    private readonly Context _context = context;

    public async Task<AddressEntity> CreateAsync(AddressEntity entity)
    {
        AddressEntity addedStateEntity = _context.Addresses.Add(entity).Entity;
        await _context.SaveChangesAsync();
        return addedStateEntity;
    }
    public async Task<IEnumerable<AddressEntity>> GetAllAsync()
    {
        IEnumerable<AddressEntity> Addresses = await _context.Addresses.ToListAsync();
        return Addresses;
    }
    public async Task<IEnumerable<AddressEntity>> GetAllFromUserAsync(string userId)
    {
        IEnumerable<AddressEntity> accounts = await _context.Addresses.Where(x => x.UserId == userId).ToListAsync();
        return accounts!;
    }
    public async Task<AddressEntity> GetOneAsync(int addressId)
    {
        AddressEntity? address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == addressId);
        return address!;
    }
    public async Task<AddressEntity> UpdateAsync(AddressEntity entity)
    {
        AddressEntity modifiedStateEntity = _context.Update(entity).Entity;
        await _context.SaveChangesAsync();
        return modifiedStateEntity;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        AddressEntity? address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
        if (address != null)
        {
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
    public async Task<bool> ExistsAsync(Expression<Func<AddressEntity, bool>> predicate)
    {
        return await _context.Addresses.AnyAsync(predicate);
    }
}