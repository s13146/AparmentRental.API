﻿// <auto-generated />
using System;
using AparmentRental.Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AparmentRental.Infastructure.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20220409165649_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("AparmentRental.Core.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddresId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAccountActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("AparmentRental.Core.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddresId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BulidNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FlatNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddresId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("AparmentRental.Core.Entities.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Floor")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsElevator")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LandlordId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TenantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("LandlordId");

                    b.HasIndex("TenantId")
                        .IsUnique();

                    b.ToTable("Apartment");
                });

            modelBuilder.Entity("AparmentRental.Core.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("AparmentRental.Core.Entities.Landlord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Landlord");
                });

            modelBuilder.Entity("AparmentRental.Core.Entities.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("AparmentRental.Core.Entities.Account", b =>
                {
                    b.HasOne("AparmentRental.Core.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("AparmentRental.Core.Entities.Address", b =>
                {
                    b.HasOne("AparmentRental.Core.Entities.Address", "Addres")
                        .WithMany()
                        .HasForeignKey("AddresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Addres");
                });

            modelBuilder.Entity("AparmentRental.Core.Entities.Apartment", b =>
                {
                    b.HasOne("AparmentRental.Core.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AparmentRental.Core.Entities.Landlord", "Landlord")
                        .WithMany("Apartments")
                        .HasForeignKey("LandlordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AparmentRental.Core.Entities.Tenant", "Tenant")
                        .WithOne("Apartment")
                        .HasForeignKey("AparmentRental.Core.Entities.Apartment", "TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Landlord");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("AparmentRental.Core.Entities.Image", b =>
                {
                    b.HasOne("AparmentRental.Core.Entities.Apartment", "Apartment")
                        .WithMany("Images")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("AparmentRental.Core.Entities.Landlord", b =>
                {
                    b.HasOne("AparmentRental.Core.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("AparmentRental.Core.Entities.Tenant", b =>
                {
                    b.HasOne("AparmentRental.Core.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("AparmentRental.Core.Entities.Apartment", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("AparmentRental.Core.Entities.Landlord", b =>
                {
                    b.Navigation("Apartments");
                });

            modelBuilder.Entity("AparmentRental.Core.Entities.Tenant", b =>
                {
                    b.Navigation("Apartment")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}