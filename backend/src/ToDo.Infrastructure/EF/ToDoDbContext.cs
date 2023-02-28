using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDo.Core.Abstractions;
using ToDo.Core.Entities;

namespace ToDo.Infrastructure.EF;

public class ToDoDbContext : DbContext
{
    private readonly IClock _clock;

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options, IClock clock) : base(options)
    {
        _clock = clock;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<ToDoList> ToDoLists { get; set; }
    public DbSet<ToDoItem> ToDoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        SeedExampleData(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private void SeedExampleData(ModelBuilder modelBuilder)
    {
        var firstUser = new User("johndoe23",
            "AQAAAAEAACcQAAAAELb8RYqJdzn7PLBd+LYUfJn41mOC14H7ygPPLYW0R5eQxEoMVo3ztNlSNSaZ+Kcl7w==");
        var nextUser = new User("janedoe84",
            "AQAAAAEAACcQAAAAEIPSI/aIdKAHjhvblFJggL1gRyOx5vHTHgGtovz03EPuOfgZ8Tm7o4vWgXk9YWyHKw==");
        var firstUserList1 = new ToDoList("Home", firstUser.UserId);
        var firstUserList2 = new ToDoList("Work", firstUser.UserId);
        var nextUserList1 = new ToDoList("Audio", nextUser.UserId);
        var firstUserList1Item1 = ToDoItem.CreateNewToDoItem("clean the kitchen", "take out the trash", "do not forget about segregation",
            _clock.CurrentDay().AddDays(1), firstUserList1.ToDoListId, _clock);
        var firstUserList1Item2 = ToDoItem.CreateNewToDoItem("pay bills", "electricity bill", "check fees",
            _clock.CurrentDay().AddDays(7), firstUserList1.ToDoListId, _clock);
        var firstUserList2Item1 = ToDoItem.CreateNewToDoItem("call to Jane", "mes system", "+1 4155551234",
            _clock.CurrentDay().AddDays(3), firstUserList2.ToDoListId, _clock);
        var nextUserList1Item1 = ToDoItem.CreateNewToDoItem("headphones", "with good noise cancellin", "SonicSolution xtr",
            _clock.CurrentDay().AddDays(5), nextUserList1.ToDoListId, _clock);
        var nextUserList1Item2 = ToDoItem.CreateNewToDoItem("bluetooth speaker", "waterproof", "SounDigi",
            _clock.CurrentDay(), nextUserList1.ToDoListId, _clock);
        modelBuilder.Entity<User>().HasData(firstUser, nextUser);
        modelBuilder.Entity<ToDoList>().HasData(firstUserList1, firstUserList2, nextUserList1);
        modelBuilder.Entity<ToDoItem>().HasData(firstUserList1Item1, firstUserList1Item2, firstUserList2Item1, nextUserList1Item1,
			nextUserList1Item2);
    }
}