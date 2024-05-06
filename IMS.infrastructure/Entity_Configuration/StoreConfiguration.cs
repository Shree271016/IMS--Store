using IMS.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.infrastructure.Entity_Configuration
{
    public class StoreConfiguration : IEntityTypeConfiguration<StoreInfo>
    {
        public void Configure(EntityTypeBuilder<StoreInfo> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.StoreName).IsUnicode(true);
            builder.Property(e => e.Address).IsUnicode(true);
            builder.Property(e => e.phoneNumber).IsUnicode(true);
            builder.Property(e => e.RegistratinNo).IsUnicode(true);
            builder.Property(e => e.PanNo).IsUnicode(true);
            builder.Property(e => e.IsActive);
            //.HasDefaultValue(true);
            builder.Property(e => e.CreatedBy).IsUnicode(true);
            builder.Property(e => e.CreatedDate);
            //.HasDefaultValueSql("GETDATE()");
        }
    }
}
