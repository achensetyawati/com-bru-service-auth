using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Com.Bateeq.Service.Auth.Lib.Migrations
{
    public partial class Add_Table_Store : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: false),
                    LastModifiedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedUtc = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 255, nullable: false),
                    DeletedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    City = table.Column<string>(maxLength: 255, nullable: true),
                    ClosedDate = table.Column<DateTimeOffset>(nullable: false),
                    Code = table.Column<string>(maxLength: 3000, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    MonthlyTotalCost = table.Column<float>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    OnlineOffline = table.Column<string>(maxLength: 255, nullable: true),
                    OpenedDate = table.Column<DateTimeOffset>(nullable: false),
                    Pic = table.Column<string>(maxLength: 255, nullable: true),
                    Phone = table.Column<string>(maxLength: 255, nullable: true),
                    SalesCapital = table.Column<float>(nullable: false),
                    SalesCategory = table.Column<string>(maxLength: 255, nullable: true),
                    SalesTarget = table.Column<float>(nullable: false),
                    Status = table.Column<string>(maxLength: 255, nullable: true),
                    StoreArea = table.Column<string>(maxLength: 255, nullable: true),
                    StoreCategory = table.Column<string>(maxLength: 255, nullable: true),
                    StoreWide = table.Column<string>(maxLength: 255, nullable: true),
                    Uid = table.Column<string>(maxLength: 255, nullable: true),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AccountId",
                table: "Stores",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
