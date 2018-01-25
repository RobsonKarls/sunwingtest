using System;
using System.ComponentModel.DataAnnotations;
using ContactManager.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManager.API.Infrastructure.EntityConfiguration
{
    public class CostumerEntityConfiguration : IEntityTypeConfiguration<Costumer>
    {
        public void Configure(EntityTypeBuilder<Costumer> builder)
        {
            builder.Property(x => x.Email).IsRequired();
            builder.Property<DateTime?>(x => x.BirthDate).IsRequired(false);

        }
    }
}