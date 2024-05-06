

using IMS.infrastructure.Entity_Configuration;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure
{
    public class IMSDbContext :DbContext
    {
        public IMSDbContext(DbContextOptions<IMSDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StoreConfiguration());
        }
    }



}