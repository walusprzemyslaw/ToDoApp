using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Infrastructure.Migrations
{
    public partial class SeedData4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("3f05dc62-3467-4486-8105-6952a1e142e0"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("6e5bb5b6-80a7-4f09-9e7d-62d20dcea7e4"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("ba3282cb-3ddc-4bac-933e-8c7010274fed"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("bae11e95-dd2e-4039-822a-fb4ab9947838"));

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ToDoListId",
                keyValue: new Guid("265217c0-acff-4e87-b3cb-e4c3800efdc0"));

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ToDoListId",
                keyValue: new Guid("40ce6fbf-c8de-4542-8d9f-0d8b079ec8e0"));

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ToDoListId",
                keyValue: new Guid("5fb234a3-ac32-42ed-a85c-8c93f628d721"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ccfb5104-4606-464d-8d28-c8c6e3a0a10e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("d6480d35-0c2a-4a7b-a894-3c1c20997249"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Username" },
                values: new object[] { new Guid("8eb51707-b6b3-4eaf-9c19-998e00465ba1"), "AQAAAAEAACcQAAAAELb8RYqJdzn7PLBd+LYUfJn41mOC14H7ygPPLYW0R5eQxEoMVo3ztNlSNSaZ+Kcl7w==", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Username" },
                values: new object[] { new Guid("9d64ab76-09be-40c6-af6c-face028f00da"), "AQAAAAEAACcQAAAAEIPSI/aIdKAHjhvblFJggL1gRyOx5vHTHgGtovz03EPuOfgZ8Tm7o4vWgXk9YWyHKw==", "test" });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "HiddenFinishedItems", "Name", "UserId", "Visibility" },
                values: new object[] { new Guid("7342b3d6-fe52-4961-8d5c-54d7f1d61238"), false, "test list1", new Guid("9d64ab76-09be-40c6-af6c-face028f00da"), true });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "HiddenFinishedItems", "Name", "UserId", "Visibility" },
                values: new object[] { new Guid("c0d4fa45-4484-446e-b805-940e8697195d"), false, "Admin list2", new Guid("8eb51707-b6b3-4eaf-9c19-998e00465ba1"), true });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "HiddenFinishedItems", "Name", "UserId", "Visibility" },
                values: new object[] { new Guid("df656403-beb1-4d29-bf39-484d714944d0"), false, "Admin list1", new Guid("8eb51707-b6b3-4eaf-9c19-998e00465ba1"), true });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "ToDoItemId", "CreatedDate", "Description", "DueDate", "Name", "Notes", "Status", "ToDoListId" },
                values: new object[,]
                {
                    { new Guid("3532bfda-134d-44ff-81fb-6f1311698d09"), new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), "second item", new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), "Second user item", "high priority", 0, new Guid("7342b3d6-fe52-4961-8d5c-54d7f1d61238") },
                    { new Guid("3da73fe5-a98a-466c-a902-5f6fff1e56c6"), new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), "first item", new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Local), "Item1", "high priority", 0, new Guid("df656403-beb1-4d29-bf39-484d714944d0") },
                    { new Guid("5691f188-650c-4b4f-90d5-6699c10c7c91"), new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), "second item", new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Local), "Item2", "low priority", 0, new Guid("df656403-beb1-4d29-bf39-484d714944d0") },
                    { new Guid("7ff94a87-807c-4cc1-9b75-2fd48dfbb8dc"), new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), "first item", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Local), "Item1", "high priority", 0, new Guid("c0d4fa45-4484-446e-b805-940e8697195d") },
                    { new Guid("c1259c08-9c8a-4528-8815-a6b1b4812e0d"), new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Local), "first item", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Local), "First user item", "high priority", 0, new Guid("7342b3d6-fe52-4961-8d5c-54d7f1d61238") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("3532bfda-134d-44ff-81fb-6f1311698d09"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("3da73fe5-a98a-466c-a902-5f6fff1e56c6"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("5691f188-650c-4b4f-90d5-6699c10c7c91"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("7ff94a87-807c-4cc1-9b75-2fd48dfbb8dc"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("c1259c08-9c8a-4528-8815-a6b1b4812e0d"));

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ToDoListId",
                keyValue: new Guid("7342b3d6-fe52-4961-8d5c-54d7f1d61238"));

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ToDoListId",
                keyValue: new Guid("c0d4fa45-4484-446e-b805-940e8697195d"));

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ToDoListId",
                keyValue: new Guid("df656403-beb1-4d29-bf39-484d714944d0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8eb51707-b6b3-4eaf-9c19-998e00465ba1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("9d64ab76-09be-40c6-af6c-face028f00da"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Username" },
                values: new object[] { new Guid("ccfb5104-4606-464d-8d28-c8c6e3a0a10e"), "AQAAAAEAACcQAAAAEIPSI/aIdKAHjhvblFJggL1gRyOx5vHTHgGtovz03EPuOfgZ8Tm7o4vWgXk9YWyHKw==", "test" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Username" },
                values: new object[] { new Guid("d6480d35-0c2a-4a7b-a894-3c1c20997249"), "AQAAAAEAACcQAAAAELb8RYqJdzn7PLBd+LYUfJn41mOC14H7ygPPLYW0R5eQxEoMVo3ztNlSNSaZ+Kcl7w==", "admin" });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "HiddenFinishedItems", "Name", "UserId", "Visibility" },
                values: new object[] { new Guid("265217c0-acff-4e87-b3cb-e4c3800efdc0"), false, "test list1", new Guid("ccfb5104-4606-464d-8d28-c8c6e3a0a10e"), true });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "HiddenFinishedItems", "Name", "UserId", "Visibility" },
                values: new object[] { new Guid("40ce6fbf-c8de-4542-8d9f-0d8b079ec8e0"), false, "Admin list2", new Guid("d6480d35-0c2a-4a7b-a894-3c1c20997249"), true });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "HiddenFinishedItems", "Name", "UserId", "Visibility" },
                values: new object[] { new Guid("5fb234a3-ac32-42ed-a85c-8c93f628d721"), false, "Admin list1", new Guid("d6480d35-0c2a-4a7b-a894-3c1c20997249"), true });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "ToDoItemId", "CreatedDate", "Description", "DueDate", "Name", "Notes", "Status", "ToDoListId" },
                values: new object[,]
                {
                    { new Guid("3f05dc62-3467-4486-8105-6952a1e142e0"), new DateTime(2023, 2, 26, 13, 36, 36, 933, DateTimeKind.Local).AddTicks(210), "first item", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Local), "First user item", "high priority", 0, new Guid("265217c0-acff-4e87-b3cb-e4c3800efdc0") },
                    { new Guid("6e5bb5b6-80a7-4f09-9e7d-62d20dcea7e4"), new DateTime(2023, 2, 26, 13, 36, 36, 933, DateTimeKind.Local).AddTicks(205), "first item", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Local), "Item1", "high priority", 0, new Guid("40ce6fbf-c8de-4542-8d9f-0d8b079ec8e0") },
                    { new Guid("ba3282cb-3ddc-4bac-933e-8c7010274fed"), new DateTime(2023, 2, 26, 13, 36, 36, 933, DateTimeKind.Local).AddTicks(178), "first item", new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Local), "Item1", "high priority", 0, new Guid("5fb234a3-ac32-42ed-a85c-8c93f628d721") },
                    { new Guid("bae11e95-dd2e-4039-822a-fb4ab9947838"), new DateTime(2023, 2, 26, 13, 36, 36, 933, DateTimeKind.Local).AddTicks(199), "second item", new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Local), "Item2", "low priority", 0, new Guid("5fb234a3-ac32-42ed-a85c-8c93f628d721") }
                });
        }
    }
}
