﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace Core.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Models.Business", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<decimal>("RankIncome")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("RankOutcome")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("business");
                });

            modelBuilder.Entity("Core.Models.CategoryExpense", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("RankExpense")
                        .HasColumnType("longtext");

                    b.Property<string>("SoucreName")
                        .HasColumnType("longtext");

                    b.Property<string>("SoucreType")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("category_expense");
                });

            modelBuilder.Entity("Core.Models.CategoryInCome", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("RankImcome")
                        .HasColumnType("longtext");

                    b.Property<string>("SoucreName")
                        .HasColumnType("longtext");

                    b.Property<string>("SoucreType")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("category_income");
                });

            modelBuilder.Entity("Core.Models.ConfigCorp", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Key")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("config_corp");
                });

            modelBuilder.Entity("Core.Models.Contact", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("CorporationName")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("Tax")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserID")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("contact");
                });

            modelBuilder.Entity("Core.Models.Customer.Identity.Position", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Action")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("position");
                });

            modelBuilder.Entity("Core.Models.Customer.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("ContractId")
                        .HasColumnType("longtext");

                    b.Property<string>("CorporationId")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsUserCorporation")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Core.Models.Customer.Personal.Profile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Job")
                        .HasColumnType("longtext");

                    b.Property<string>("Logo")
                        .HasColumnType("longtext");

                    b.Property<string>("PosionId")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserID")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("profile");
                });

            modelBuilder.Entity("Core.Models.DetailExpense", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("CategoryIExpenseId")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsPaymented")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsTax")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PaymentWithExpenseId")
                        .HasColumnType("longtext");

                    b.Property<string>("Period")
                        .HasColumnType("longtext");

                    b.Property<bool?>("TaxPercentage")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("detail_expense");
                });

            modelBuilder.Entity("Core.Models.DetailInCome", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("CategoryIncomeId")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsTax")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("TaxPercentage")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("detail_income");
                });

            modelBuilder.Entity("Core.Models.HistoryChangeExpense", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ActionType")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DataNew")
                        .HasColumnType("longtext");

                    b.Property<string>("DataOld")
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserID")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("history_change_expense");
                });

            modelBuilder.Entity("Core.Models.HistoryChangeIncome", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ActionType")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DataNew")
                        .HasColumnType("longtext");

                    b.Property<string>("DataOld")
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserID")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("history_change_income");
                });

            modelBuilder.Entity("Core.Models.HistoryChangeInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ActionType")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DataNew")
                        .HasColumnType("longtext");

                    b.Property<string>("DataOld")
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserID")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("history_change_info");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Core.Models.Customer.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Core.Models.Customer.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.Customer.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Core.Models.Customer.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
