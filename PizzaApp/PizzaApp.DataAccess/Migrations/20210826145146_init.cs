using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaApp.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PizzaSize",
                columns: table => new
                {
                    PizzaSizeId = table.Column<int>(nullable: false),
                    PizzaSize = table.Column<string>(unicode: false, fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaSize", x => x.PizzaSizeId);
                });

            migrationBuilder.CreateTable(
                name: "PizzaType",
                columns: table => new
                {
                    PizzaTypeId = table.Column<int>(nullable: false),
                    PizzaType = table.Column<string>(unicode: false, fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaType", x => x.PizzaTypeId);
                });

            migrationBuilder.CreateTable(
                name: "StateType",
                columns: table => new
                {
                    StateTypeId = table.Column<int>(nullable: false),
                    StateType = table.Column<string>(unicode: false, fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateType", x => x.StateTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaTypeId = table.Column<int>(nullable: false),
                    PizzaSizeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pizza_size",
                        column: x => x.PizzaSizeId,
                        principalTable: "PizzaSize",
                        principalColumn: "PizzaSizeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pizza_type",
                        column: x => x.PizzaTypeId,
                        principalTable: "PizzaType",
                        principalColumn: "PizzaTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_state_type",
                        column: x => x.StateTypeId,
                        principalTable: "StateType",
                        principalColumn: "StateTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSubmited = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDelivered = table.Column<bool>(nullable: false),
                    PizzaId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pizza",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_state",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentStateId = table.Column<int>(nullable: false),
                    NextStateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_current_state",
                        column: x => x.CurrentStateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_next_state",
                        column: x => x.NextStateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PizzaSize",
                columns: new[] { "PizzaSizeId", "PizzaSize" },
                values: new object[,]
                {
                    { 1, "Small" },
                    { 2, "Medium" },
                    { 3, "Large" },
                    { 4, "Family" }
                });

            migrationBuilder.InsertData(
                table: "PizzaType",
                columns: new[] { "PizzaTypeId", "PizzaType" },
                values: new object[,]
                {
                    { 1, "Capri" },
                    { 2, "Margaritha" },
                    { 3, "Funghi" },
                    { 4, "Peperoni" },
                    { 5, "Stelato" },
                    { 6, "Vege" }
                });

            migrationBuilder.InsertData(
                table: "StateType",
                columns: new[] { "StateTypeId", "StateType" },
                values: new object[,]
                {
                    { 1, "Preparing" },
                    { 2, "Baking" },
                    { 3, "Delivering" },
                    { 4, "Delivered" },
                    { 5, "Canceled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PizzaId",
                table: "Orders",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StateId",
                table: "Orders",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_PizzaSizeId",
                table: "Pizzas",
                column: "PizzaSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_PizzaTypeId",
                table: "Pizzas",
                column: "PizzaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_States_StateTypeId",
                table: "States",
                column: "StateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_CurrentStateId",
                table: "Transitions",
                column: "CurrentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_NextStateId",
                table: "Transitions",
                column: "NextStateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Transitions");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "PizzaSize");

            migrationBuilder.DropTable(
                name: "PizzaType");

            migrationBuilder.DropTable(
                name: "StateType");
        }
    }
}
