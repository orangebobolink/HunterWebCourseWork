﻿// <auto-generated />
using System;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.AnimalEntities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalDetailId")
                        .HasColumnType("int");

                    b.Property<int?>("HuntingSeasonId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AnimalDetailId");

                    b.HasIndex("HuntingSeasonId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("DAL.Entities.AnimalEntities.AnimalDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnimalDetail");
                });

            modelBuilder.Entity("DAL.Entities.HuntingSeasonEntities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("DAL.Entities.HuntingSeasonEntities.HuntingSeason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("date");

                    b.Property<int>("HuntingSeasonDetailId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HuntingSeasonDetailId");

                    b.ToTable("HuntingSeasons");
                });

            modelBuilder.Entity("DAL.Entities.HuntingSeasonEntities.HuntingSeasonDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("HuntingTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MethodOfHuntingId")
                        .HasColumnType("int");

                    b.Property<int?>("TypeOfHuntingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("MethodOfHuntingId");

                    b.HasIndex("TypeOfHuntingId");

                    b.ToTable("HuntingSeasonDetail");
                });

            modelBuilder.Entity("DAL.Entities.HuntingSeasonEntities.MethodOfHunting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Methods");
                });

            modelBuilder.Entity("DAL.Entities.HuntingSeasonEntities.TypeOfHunting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Types");
                });

            modelBuilder.Entity("DAL.Entities.Messanger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Messangers");
                });

            modelBuilder.Entity("DAL.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountDates")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FilingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IncludeHouse")
                        .HasColumnType("bit");

                    b.Property<int?>("MessangerId")
                        .HasColumnType("int");

                    b.Property<int>("NumberHunters")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessangerId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DAL.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("DAL.Entities.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("DAL.Entities.UserEntities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DAL.Entities.UserEntities.RoleUser", b =>
                {
                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("DAL.Entities.UserEntities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Entities.UserEntities.UserDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MessangerId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessangerId");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserDetail");
                });

            modelBuilder.Entity("DAL.Entities.AnimalEntities.Animal", b =>
                {
                    b.HasOne("DAL.Entities.AnimalEntities.AnimalDetail", "AnimalDetail")
                        .WithMany()
                        .HasForeignKey("AnimalDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.HuntingSeasonEntities.HuntingSeason", "HuntingSeason")
                        .WithMany()
                        .HasForeignKey("HuntingSeasonId");

                    b.Navigation("AnimalDetail");

                    b.Navigation("HuntingSeason");
                });

            modelBuilder.Entity("DAL.Entities.HuntingSeasonEntities.HuntingSeason", b =>
                {
                    b.HasOne("DAL.Entities.HuntingSeasonEntities.HuntingSeasonDetail", "HuntingSeasonDetail")
                        .WithMany()
                        .HasForeignKey("HuntingSeasonDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HuntingSeasonDetail");
                });

            modelBuilder.Entity("DAL.Entities.HuntingSeasonEntities.HuntingSeasonDetail", b =>
                {
                    b.HasOne("DAL.Entities.HuntingSeasonEntities.Gender", "Gender")
                        .WithMany("HuntingSeasonDetails")
                        .HasForeignKey("GenderId");

                    b.HasOne("DAL.Entities.HuntingSeasonEntities.MethodOfHunting", "MethodOfHunting")
                        .WithMany("HuntingSeasonDetails")
                        .HasForeignKey("MethodOfHuntingId");

                    b.HasOne("DAL.Entities.HuntingSeasonEntities.TypeOfHunting", "TypeOfHunting")
                        .WithMany("HuntingSeasonDetails")
                        .HasForeignKey("TypeOfHuntingId");

                    b.Navigation("Gender");

                    b.Navigation("MethodOfHunting");

                    b.Navigation("TypeOfHunting");
                });

            modelBuilder.Entity("DAL.Entities.Order", b =>
                {
                    b.HasOne("DAL.Entities.Messanger", "Messanger")
                        .WithMany("Orders")
                        .HasForeignKey("MessangerId");

                    b.HasOne("DAL.Entities.Status", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.UserEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Messanger");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Token", b =>
                {
                    b.HasOne("DAL.Entities.UserEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.UserEntities.RoleUser", b =>
                {
                    b.HasOne("DAL.Entities.UserEntities.Role", "Role")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.UserEntities.User", "User")
                        .WithMany("RoleUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.UserEntities.UserDetail", b =>
                {
                    b.HasOne("DAL.Entities.Messanger", "Messanger")
                        .WithMany("UserDetails")
                        .HasForeignKey("MessangerId");

                    b.HasOne("DAL.Entities.UserEntities.User", "User")
                        .WithOne("UserDetail")
                        .HasForeignKey("DAL.Entities.UserEntities.UserDetail", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Messanger");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.HuntingSeasonEntities.Gender", b =>
                {
                    b.Navigation("HuntingSeasonDetails");
                });

            modelBuilder.Entity("DAL.Entities.HuntingSeasonEntities.MethodOfHunting", b =>
                {
                    b.Navigation("HuntingSeasonDetails");
                });

            modelBuilder.Entity("DAL.Entities.HuntingSeasonEntities.TypeOfHunting", b =>
                {
                    b.Navigation("HuntingSeasonDetails");
                });

            modelBuilder.Entity("DAL.Entities.Messanger", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserDetails");
                });

            modelBuilder.Entity("DAL.Entities.Status", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DAL.Entities.UserEntities.Role", b =>
                {
                    b.Navigation("RoleUsers");
                });

            modelBuilder.Entity("DAL.Entities.UserEntities.User", b =>
                {
                    b.Navigation("RoleUsers");

                    b.Navigation("UserDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
