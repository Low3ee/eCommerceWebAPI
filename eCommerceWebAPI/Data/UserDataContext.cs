using eCommerceWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWebAPI.Data
{
    public class UserDataContext : DbContext
    {
            public UserDataContext(DbContextOptions<UserDataContext> options) : base(options) { }

            public DbSet<UserData> Users => Set<UserData>();
    }
}

