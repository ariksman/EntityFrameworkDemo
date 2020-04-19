# Entity framework Core optimizations

# String fields - nvarchar(max)

When defining property as `string` the ef core will define this column with `nvarchar(max)`. This can cause performance/memory problems with lookups if the extra space is not needed.

For further reading: https://www.sqlservercentral.com/forums/topic/nvarchar4000-and-performance

Fields can be further configured via fluent-api or attributes:

```CSharp
public class Sample
{
    [MaxLength(50)] // nvarchar(50)
    public string Username { get; set; }

    [Column(TypeName = "char(3)")]
    public string Currency { get; set; }

    [Column(TypeName = "date")]
    public DateTime DateOfBirth { get; set; }
}
```

```CSharp
public class SampleContext : DbContext
{
    public DbSet<Sample> Samples { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Sample>()
            .Property(sample => sample.Username)
            .HasMaxLength(50);

        modelBuilder.Entity<Sample>()
            .Property(sample => sample.Currency)
            .HasColumnType("char(3)");

        modelBuilder.Entity<Sample>()
            .Property(sample => sample.DateOfBirth)
            .ForSqlServerHasColumnType("date");
    }
}
```

# Nullable properties

There might be need to define some fields as required. Possible via data attributes or fluent-api.

```CSharp
public class Sample
{
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
}
```

```CSharp
public class SampleContext : DbContext
{
    public DbSet<Sample> Samples { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Sample>()
            .Property(sample => sample.Username)
            .IsRequired()
            .HasMaxLength(50);
    }
}
```
