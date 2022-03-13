using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<ToDo> ToDos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("DataSource=app.db;Cache=Shared");
}
