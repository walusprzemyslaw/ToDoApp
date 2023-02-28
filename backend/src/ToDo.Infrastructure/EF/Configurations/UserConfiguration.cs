using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Core.Entities;

namespace ToDo.Infrastructure.EF.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.UserId);
        builder.HasMany(x => x.ToDoLists).WithOne(x=> x.User);
        builder.HasIndex(x => x.Username).IsUnique();
        builder.Property(x => x.Password).IsRequired();
    }
}