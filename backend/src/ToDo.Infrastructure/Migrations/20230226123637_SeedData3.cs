using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Infrastructure.Migrations
{
    public partial class SeedData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("1eb76f14-0300-414e-97e1-5073ca41f997"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("3ee1a3c8-4d73-4055-8134-02d201cbbde3"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("4ccdd91b-3f56-40e9-a21d-560c63e591d3"));

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "ToDoItemId",
                keyValue: new Guid("d7500a72-ac19-4482-87cc-4a9e587c0953"));

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ToDoListId",
                keyValue: new Guid("b08bf35b-f70d-433c-afba-786f354cc52a"));

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ToDoListId",
                keyValue: new Guid("b598b227-2774-4bf2-b76d-3bec8101bbee"));

            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ToDoListId",
                keyValue: new Guid("cf4bf63e-bf9f-4312-a2d2-736bb2d8d735"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("1d079e6d-376e-4030-8c75-abbe210441fa"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("80947daf-24ce-4e6b-922b-cef29fe189df"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("1d079e6d-376e-4030-8c75-abbe210441fa"), "AQAAAAEAACcQAAAAELb8RYqJdzn7PLBd+LYUfJn41mOC14H7ygPPLYW0R5eQxEoMVo3ztNlSNSaZ+Kcl7w==", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Username" },
                values: new object[] { new Guid("80947daf-24ce-4e6b-922b-cef29fe189df"), "AQAAAAEAACcQAAAAEIPSI/aIdKAHjhvblFJggL1gRyOx5vHTHgGtovz03EPuOfgZ8Tm7o4vWgXk9YWyHKw==", "test" });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "HiddenFinishedItems", "Name", "UserId", "Visibility" },
                values: new object[] { new Guid("b08bf35b-f70d-433c-afba-786f354cc52a"), false, "test list1", new Guid("80947daf-24ce-4e6b-922b-cef29fe189df"), true });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "HiddenFinishedItems", "Name", "UserId", "Visibility" },
                values: new object[] { new Guid("b598b227-2774-4bf2-b76d-3bec8101bbee"), false, "Admin list1", new Guid("1d079e6d-376e-4030-8c75-abbe210441fa"), true });

            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ToDoListId", "HiddenFinishedItems", "Name", "UserId", "Visibility" },
                values: new object[] { new Guid("cf4bf63e-bf9f-4312-a2d2-736bb2d8d735"), false, "Admin list2", new Guid("1d079e6d-376e-4030-8c75-abbe210441fa"), true });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "ToDoItemId", "CreatedDate", "Description", "DueDate", "Name", "Notes", "Status", "ToDoListId" },
                values: new object[,]
                {
                    { new Guid("1eb76f14-0300-414e-97e1-5073ca41f997"), new DateTime(2023, 2, 26, 11, 7, 17, 574, DateTimeKind.Utc).AddTicks(2102), "second item", new DateTime(2023, 3, 5, 11, 7, 17, 574, DateTimeKind.Utc).AddTicks(2101), "Item2", "low priority", 0, new Guid("b598b227-2774-4bf2-b76d-3bec8101bbee") },
                    { new Guid("3ee1a3c8-4d73-4055-8134-02d201cbbde3"), new DateTime(2023, 2, 26, 11, 7, 17, 574, DateTimeKind.Utc).AddTicks(2096), "first item", new DateTime(2023, 2, 27, 11, 7, 17, 574, DateTimeKind.Utc).AddTicks(2090), "Item1", "high priority", 0, new Guid("b598b227-2774-4bf2-b76d-3bec8101bbee") },
                    { new Guid("4ccdd91b-3f56-40e9-a21d-560c63e591d3"), new DateTime(2023, 2, 26, 11, 7, 17, 574, DateTimeKind.Utc).AddTicks(2106), "first item", new DateTime(2023, 3, 3, 11, 7, 17, 574, DateTimeKind.Utc).AddTicks(2106), "First user item", "high priority", 0, new Guid("b08bf35b-f70d-433c-afba-786f354cc52a") },
                    { new Guid("d7500a72-ac19-4482-87cc-4a9e587c0953"), new DateTime(2023, 2, 26, 11, 7, 17, 574, DateTimeKind.Utc).AddTicks(2104), "first item", new DateTime(2023, 3, 1, 11, 7, 17, 574, DateTimeKind.Utc).AddTicks(2104), "Item1", "high priority", 0, new Guid("cf4bf63e-bf9f-4312-a2d2-736bb2d8d735") }
                });
        }
    }
}
