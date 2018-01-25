﻿// <auto-generated />
using ContactManager.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace ContactManager.API.Migrations
{
    [DbContext(typeof(ContactManagerContext))]
    [Migration("20180123030408_migrations add table for names")]
    partial class migrationsaddtablefornames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContactManager.Domain.Model.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("ContactManager.Domain.Model.Costumer", b =>
                {
                    b.HasBaseType("ContactManager.Domain.Model.Person");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.ToTable("Costumer");

                    b.HasDiscriminator().HasValue("Costumer");
                });

            modelBuilder.Entity("ContactManager.Domain.Model.Supplier", b =>
                {
                    b.HasBaseType("ContactManager.Domain.Model.Person");

                    b.Property<string>("Telephone")
                        .HasColumnType("varchar(12)")
                        .HasMaxLength(12);

                    b.ToTable("Supplier");

                    b.HasDiscriminator().HasValue("Supplier");
                });

            modelBuilder.Entity("ContactManager.Domain.Model.Person", b =>
                {
                    b.OwnsOne("ContactManager.Domain.Model.Name", "Name", b1 =>
                        {
                            b1.Property<long>("PersonId");

                            b1.Property<string>("First");

                            b1.Property<string>("Last");

                            b1.ToTable("Name");

                            b1.HasOne("ContactManager.Domain.Model.Person")
                                .WithOne("Name")
                                .HasForeignKey("ContactManager.Domain.Model.Name", "PersonId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
