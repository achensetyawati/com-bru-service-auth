using Com.Bateeq.Service.Auth.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Auth.Lib.Configs
{
    public class StoreConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(p => p.Address).HasMaxLength(255);
            builder.Property(p => p.City).HasMaxLength(255);
            builder.Property(p => p.Code).HasMaxLength(3000);
            builder.Property(p => p.Description).HasMaxLength(255);
            builder.Property(p => p.Name).HasMaxLength(255);
            builder.Property(p => p.OnlineOffline).HasMaxLength(255);
            builder.Property(p => p.Phone).HasMaxLength(255);
            builder.Property(p => p.Pic).HasMaxLength(255);
            builder.Property(p => p.SalesCategory).HasMaxLength(255);
            builder.Property(p => p.Status).HasMaxLength(255);
            builder.Property(p => p.StoreArea).HasMaxLength(255);
            builder.Property(p => p.StoreCategory).HasMaxLength(255);
            builder.Property(p => p.StoreWide).HasMaxLength(255);
            builder.Property(p => p.Uid).HasMaxLength(255);

        }
    }
}
