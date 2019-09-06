using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetailStore.Domain;

namespace RetailStore.Data.Config
{
    public class SaleOrderDetailCongfiguration : IEntityTypeConfiguration<SaleOrderDetail>
    {
        public void Configure(EntityTypeBuilder<SaleOrderDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseSqlServerIdentityColumn().ValueGeneratedOnAdd();
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.SaleOrder).WithMany(x=>x.OderDetails).HasForeignKey(x => x.SaleOrderId);

        }
    }
}
