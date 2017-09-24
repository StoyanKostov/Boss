using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication.Models;

namespace WebApplication.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20170924152707_AppDB")]
    partial class AppDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance")
                        .HasColumnType("money");

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("PasswordSalt");

                    b.Property<string>("PaswordHash");

                    b.Property<int>("Socks");

                    b.Property<string>("UserName");

                    b.Property<DateTime>("lastLogin");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
        }
    }
}
