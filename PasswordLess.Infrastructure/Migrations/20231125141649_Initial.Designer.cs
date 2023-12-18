﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PasswordLess.Infrastructure.Context;

#nullable disable

namespace PasswordLess.Infrastructure.Migrations
{
    [DbContext(typeof(PasswordLessDbContext))]
    [Migration("20231125141649_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PasswordLess.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PasswordLess.Domain.Entities.User", b =>
                {
                    b.OwnsOne("PasswordLess.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("EmailAddress")
                                .IsRequired()
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.HasIndex("EmailAddress")
                                .IsUnique();

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("PasswordLess.Domain.ValueObjects.PasswordCode", "PasswordCode", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasColumnType("varchar(16)")
                                .HasColumnName("Code");

                            b1.Property<DateTime>("ExpirationDate")
                                .HasColumnType("datetime")
                                .HasColumnName("ExpirationDate");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("PasswordLess.Domain.ValueObjects.Username", "Username", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("UsernameTyped")
                                .IsRequired()
                                .HasColumnType("varchar(30)")
                                .HasColumnName("Username");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("PasswordCode")
                        .IsRequired();

                    b.Navigation("Username")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
