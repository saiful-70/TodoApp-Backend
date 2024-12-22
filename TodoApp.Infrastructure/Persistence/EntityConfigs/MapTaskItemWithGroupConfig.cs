using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Entities;

namespace TodoApp.Infrastructure.Persistence.EntityConfigs;

public class MapTaskItemWithGroupConfig: IEntityTypeConfiguration<MapTaskItemWithGroup>
{
    public void Configure(EntityTypeBuilder<MapTaskItemWithGroup> builder)
    {
        builder.HasKey(x => new { x.TaskId, x.GroupId });
        
        builder.HasOne<TaskItem>()
            .WithMany()
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        
        builder.HasOne<TaskGroup>()
            .WithMany()
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}