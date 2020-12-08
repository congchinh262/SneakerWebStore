using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SneakerWebStore.Data.Migrations
{
    public partial class InitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustommerId = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<short>(nullable: false),
                    PaymentMethod = table.Column<short>(nullable: false),
                    PaymentStatus = table.Column<short>(nullable: false),
                    ShippingMethod = table.Column<short>(nullable: false),
                    ShippingStatus = table.Column<short>(nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustommerId",
                        column: x => x.CustommerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenericProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerId = table.Column<short>(nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericProducts_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderBillings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 450, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderBillings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderBillings_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderShippings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 450, nullable: false),
                    LastName = table.Column<string>(maxLength: 450, nullable: false),
                    ShippingAddress = table.Column<string>(maxLength: 450, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderShippings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderShippings_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenericProductCategories",
                columns: table => new
                {
                    GenericProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericProductCategories", x => new { x.GenericProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_GenericProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenericProductCategories_GenericProducts_GenericProductId",
                        column: x => x.GenericProductId,
                        principalTable: "GenericProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenericProductTags",
                columns: table => new
                {
                    GenericProductId = table.Column<int>(nullable: false),
                    TagId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericProductTags", x => new { x.GenericProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_GenericProductTags_GenericProducts_GenericProductId",
                        column: x => x.GenericProductId,
                        principalTable: "GenericProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenericProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenericProductId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    OrderType = table.Column<byte>(nullable: false),
                    Stock = table.Column<byte>(nullable: false),
                    IsBuyable = table.Column<bool>(nullable: false),
                    IsPreorderable = table.Column<bool>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificProducts_GenericProducts_GenericProductId",
                        column: x => x.GenericProductId,
                        principalTable: "GenericProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    SpecificProductId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Quantity = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.Id, x.OrderId, x.SpecificProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_SpecificProducts_SpecificProductId",
                        column: x => x.SpecificProductId,
                        principalTable: "SpecificProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificProductId = table.Column<int>(nullable: false),
                    Order = table.Column<short>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificProductImages_SpecificProducts_SpecificProductId",
                        column: x => x.SpecificProductId,
                        principalTable: "SpecificProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificProductSizes",
                columns: table => new
                {
                    SpecificProductId = table.Column<int>(nullable: false),
                    SizeId = table.Column<short>(nullable: false),
                    Detail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificProductSizes", x => new { x.SpecificProductId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_SpecificProductSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecificProductSizes_SpecificProducts_SpecificProductId",
                        column: x => x.SpecificProductId,
                        principalTable: "SpecificProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificProductTags",
                columns: table => new
                {
                    SpecificProductId = table.Column<int>(nullable: false),
                    TagId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificProductTags", x => new { x.SpecificProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_SpecificProductTags_SpecificProducts_SpecificProductId",
                        column: x => x.SpecificProductId,
                        principalTable: "SpecificProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecificProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (short)1, "Sneaker" },
                    { (short)2, "Clothes" },
                    { (short)3, "Accessory" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (short)1, "Vans" },
                    { (short)2, "Convert" },
                    { (short)3, "Adidas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenericProductCategories_CategoryId",
                table: "GenericProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GenericProducts_ManufacturerId",
                table: "GenericProducts",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_GenericProductTags_TagId",
                table: "GenericProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SpecificProductId",
                table: "OrderDetails",
                column: "SpecificProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustommerId",
                table: "Orders",
                column: "CustommerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificProductImages_SpecificProductId_Order",
                table: "SpecificProductImages",
                columns: new[] { "SpecificProductId", "Order" });

            migrationBuilder.CreateIndex(
                name: "IX_SpecificProducts_GenericProductId",
                table: "SpecificProducts",
                column: "GenericProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificProductSizes_SizeId",
                table: "SpecificProductSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificProductTags_TagId",
                table: "SpecificProductTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenericProductCategories");

            migrationBuilder.DropTable(
                name: "GenericProductTags");

            migrationBuilder.DropTable(
                name: "OrderBillings");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderShippings");

            migrationBuilder.DropTable(
                name: "SpecificProductImages");

            migrationBuilder.DropTable(
                name: "SpecificProductSizes");

            migrationBuilder.DropTable(
                name: "SpecificProductTags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "SpecificProducts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "GenericProducts");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
