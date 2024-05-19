using AddressProvider.Data.Entities;
using System.Linq.Expressions;

namespace AddressProvider.Interfaces;

public interface IAddressRepository
{
    Task<AddressEntity> CreateAsync(AddressEntity entity);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(Expression<Func<AddressEntity, bool>> predicate);
    Task<IEnumerable<AddressEntity>> GetAllAsync();
    Task<IEnumerable<AddressEntity>> GetAllFromUserAsync(string userId);
    Task<AddressEntity> GetOneAsync(int addressId);
    Task<AddressEntity> UpdateAsync(AddressEntity entity);
}