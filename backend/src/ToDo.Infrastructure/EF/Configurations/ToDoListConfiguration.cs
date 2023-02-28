using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Core.Entities;

namespace ToDo.Infrastructure.EF.Configurations;

public class ToDoListConfiguration: IEntityTypeConfiguration<ToDoList>
{
    public void Configure(EntityTypeBuilder<ToDoList> builder)
    {
        builder.HasKey(x => x.ToDoListId);
        builder.HasOne(x => x.User)
            .WithMany(x => x.ToDoLists)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Visibility).IsRequired();
        builder.Property(x => x.HiddenFinishedItems).IsRequired();
    }
}