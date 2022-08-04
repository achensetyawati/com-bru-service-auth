using Com.Bateeq.Service.Auth.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Bateeq.Service.Auth.Lib.Configs
{
    public class AccountRoleConfig : IEntityTypeConfiguration<AccountRole>
    {
        public void Configure(EntityTypeBuilder<AccountRole> builder)
        {
            builder.Property(p => p.RoleUId).HasMaxLength(255);
            builder.Property(p => p.UId).HasMaxLength(255);
        }
    }
}
