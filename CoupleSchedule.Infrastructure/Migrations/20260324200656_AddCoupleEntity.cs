using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoupleSchedule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCoupleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "couples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PartnerOneId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartnerTwoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_couples", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_couples_PartnerOneId_PartnerTwoId",
                table: "couples",
                columns: new[] { "PartnerOneId", "PartnerTwoId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "couples");
        }
    }
}
