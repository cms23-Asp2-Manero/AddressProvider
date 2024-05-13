using AddressProvider.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AddressProvider.Data.Contexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<AddressEntity> Addresses { get; set; }
}
