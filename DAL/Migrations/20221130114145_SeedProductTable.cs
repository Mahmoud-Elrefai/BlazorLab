using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into products (name , price) values ('product1' , 30)");
            migrationBuilder.Sql("insert into products (name , price) values ('product2' , 40)");
            migrationBuilder.Sql("insert into products (name , price) values ('product3' , 50)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from products");

        }
    }
}
