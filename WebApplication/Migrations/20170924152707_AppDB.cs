using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication.Migrations
{
    public partial class AppDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Balance = table.Column<decimal>(type: "money", nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    PaswordHash = table.Column<string>(nullable: true),
                    Socks = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    lastLogin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
