using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Core.Entities;

namespace ToDo.Infrastructure.EF.Configurations;

public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
    public void Configure(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.HasKey(x => x.ToDoItemId);
        builder.HasOne(x => x.ToDoList)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.ToDoListId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.DueDate).IsRequired();
        builder.Property(x => x.Status).IsRequired();
    }
}