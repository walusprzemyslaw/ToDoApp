using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Username" },
                values: new object[] { new Guid("20a772cb-4f2c-4d59-9f12-ee961def6846"), "AQAAAAEAACcQAAAAEIPSI/aIdKAHjhvblFJggL1gRyOx5vHTHgGtovz03EPuOfgZ8Tm7o4vWgXk9YWyHKw==", "test" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Username" },
                values: new object[] { new Guid("7aa75f54-70fb-4732-8f16-d95e39f7a5ff"), "AQAAAAEAACcQAAAAELb8RYqJdzn7PLBd+LYUfJn41mOC14H7ygPPLYW0R5eQxEoMVo3ztNlSNSaZ+Kcl7w==", "admin" });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "HiddenFinishedItems", "Name", "UserId", "Visibility" },
                values: new object[] { new Guid("1c4b2224-996e-42b7-9507-c74d0e555d9d"), false, "Admin list1", new Guid("7aa75f54-70fb-4732-8f16-d95e39f7a5ff"), true });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "HiddenFinishedItems", "Name", "UserId", "Visibility" },
                values: new object[] { new Guid("7c607b0b-de07-4e12-8f94-c2bcc59bd58b"), false, "test list1", new Guid("7aa75f54-70fb-4732-8f16-d95e39f7a5ff"), true });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "HiddenFinishedItems", "Name", "UserId", "Visibility" },
                values: new object[] { new Guid("b42cf5f2-ff2d-4242-a3ea-18fe532322dc"), false, "Admin list2", new Guid("7aa75f54-70fb-4732-8f16-d95e39f7a5ff"), true });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "ToDoItemId", "CreatedDate", "Description", "DueDate", "Name", "Notes", "Status", "ToDoListId" },
                values: new object[,]
                {
                    { new Guid("298b4d1d-a6b4-4d9d-a8ef-d1ee66327083"), new DateTime(2023, 2, 26, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5638), "first item", new DateTime(2023, 3, 1, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5637), "Item1", "high priority", 0, new Guid("b42cf5f2-ff2d-4242-a3ea-18fe532322dc") },
                    { new Guid("47d21314-6489-4bd4-9b81-cbf433c585f4"), new DateTime(2023, 2, 26, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5635), "second item", new DateTime(2023, 3, 5, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5634), "Item2", "low priority", 0, new Guid("1c4b2224-996e-42b7-9507-c74d0e555d9d") },
                    { new Guid("867fc645-0b1e-4037-a80b-6836ad733a90"), new DateTime(2023, 2, 26, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5627), "first item", new DateTime(2023, 2, 27, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5620), "Item1", "high priority", 0, new Guid("1c4b2224-996e-42b7-9507-c74d0e555d9d") },
                    { new Guid("b526968a-a7e8-4630-b811-0a032528f8f0"), new DateTime(2023, 2, 26, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5640), "first item", new DateTime(2023, 3, 3, 9, 56, 17, 529, DateTimeKind.Utc).AddTicks(5640), "First user item", "high priority", 0, new Guid("7c607b0b-de07-4e12-8f94-c2bcc59bd58b") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("298b4d1d-a6b4-4d9d-a8ef-d1ee66327083"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("47d21314-6489-4bd4-9b81-cbf433c585f4"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("867fc645-0b1e-4037-a80b-6836ad733a90"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("b526968a-a7e8-4630-b811-0a032528f8f0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("20a772cb-4f2c-4d59-9f12-ee961def6846"));

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ToDoListId",
                keyValue: new Guid("1c4b2224-996e-42b7-9507-c74d0e555d9d"));

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ToDoListId",
                keyValue: new Guid("7c607b0b-de07-4e12-8f94-c2bcc59bd58b"));

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ToDoListId",
                keyValue: new Guid("b42cf5f2-ff2d-4242-a3ea-18fe532322dc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7aa75f54-70fb-4732-8f16-d95e39f7a5ff"));
        }
    }
}
