﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiyasMatrimony.API.Data;

namespace SiyasMatrimony.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190507133926_CountryStateCityAdded")]
    partial class CountryStateCityAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.Caste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ReligionId");

                    b.HasKey("Id");

                    b.HasIndex("ReligionId");

                    b.ToTable("Castes");
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.City", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("country_id");

                    b.Property<string>("name");

                    b.Property<int>("state_id");

                    b.HasKey("id");

                    b.HasIndex("country_id");

                    b.HasIndex("state_id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("capital");

                    b.Property<string>("currency");

                    b.Property<string>("iso2");

                    b.Property<string>("iso3");

                    b.Property<string>("name");

                    b.Property<string>("phone_code");

                    b.HasKey("id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<bool>("IsMain");

                    b.Property<string>("PublicId");

                    b.Property<string>("Url");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.Rashi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("StarId");

                    b.HasKey("Id");

                    b.HasIndex("StarId");

                    b.ToTable("Rashis");
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.Religion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Religions");
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.Star", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Stars");
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.State", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("country_id");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.HasIndex("country_id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("BodyType");

                    b.Property<string>("CallingCode");

                    b.Property<string>("Cast");

                    b.Property<string>("ChovvaDosam");

                    b.Property<string>("City");

                    b.Property<string>("Complexion");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Currency");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Drinking");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("EmploymentType");

                    b.Property<string>("FamilyStatus");

                    b.Property<string>("FamilyType");

                    b.Property<string>("FamilyValues");

                    b.Property<string>("FoodHabits");

                    b.Property<string>("Gender");

                    b.Property<string>("Height");

                    b.Property<string>("HighestQualification");

                    b.Property<string>("Interests");

                    b.Property<string>("Introduction");

                    b.Property<DateTime>("LastActive");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("LookingFor");

                    b.Property<string>("MaritalStatus");

                    b.Property<string>("MobileNumber");

                    b.Property<string>("MonthlyIncome");

                    b.Property<string>("MotherTongue");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("Occupation");

                    b.Property<string>("ParentsMobileNumber");

                    b.Property<string>("ParentsMonthlyIncome");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PhysicalStatus");

                    b.Property<string>("PinCode");

                    b.Property<string>("ProfileCreatedFor");

                    b.Property<string>("Raasi");

                    b.Property<string>("Religion");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Smoking");

                    b.Property<string>("Star");

                    b.Property<string>("State");

                    b.Property<string>("SubCast");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("Weight");

                    b.Property<string>("timeOfBirth");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("SiyasMatrimony.API.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("SiyasMatrimony.API.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("SiyasMatrimony.API.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("SiyasMatrimony.API.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.Caste", b =>
                {
                    b.HasOne("SiyasMatrimony.API.Models.Religion", "Religion")
                        .WithMany("Castes")
                        .HasForeignKey("ReligionId");
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.City", b =>
                {
                    b.HasOne("SiyasMatrimony.API.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("country_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SiyasMatrimony.API.Models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("state_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.Photo", b =>
                {
                    b.HasOne("SiyasMatrimony.API.Models.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.Rashi", b =>
                {
                    b.HasOne("SiyasMatrimony.API.Models.Star", "Star")
                        .WithMany("Rashi")
                        .HasForeignKey("StarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.State", b =>
                {
                    b.HasOne("SiyasMatrimony.API.Models.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("country_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SiyasMatrimony.API.Models.UserRole", b =>
                {
                    b.HasOne("SiyasMatrimony.API.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SiyasMatrimony.API.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
