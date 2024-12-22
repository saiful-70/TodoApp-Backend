using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Entities;

namespace TodoApp.Infrastructure.Persistence.EntityConfigs;

public class TaskItemConfig: IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
       builder.Property(x => x.Id).ValueGeneratedNever();
       builder.Property(x => x.Title).HasMaxLength(300);
       builder.Property(x => x.Description).HasMaxLength(500);
    }
}