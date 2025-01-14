﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer.Data.EntityTypeConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Player",
                    NormalizedName = "PLAYER",
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMIN",
                }
            ); 
        }
    }
}
