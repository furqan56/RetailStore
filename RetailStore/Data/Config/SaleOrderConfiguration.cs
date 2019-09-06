using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetailStore.Domain;

namespace RetailStore.Data.Config
{
    public class CustomerConfigration : IEntityTypeConfiguration<SaleOrder>
    {
        public void Configure(EntityTypeBuilder<SaleOrder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseSqlServerIdentityColumn<int>().ValueGeneratedOnAdd();
            builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);
            
        }
    }
}
