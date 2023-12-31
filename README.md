# Project "004_EF"

This project is an example of using Entity Framework (EF) to create a phone company application.


## Project Features

- Uses Entity Framework Code First approach.
- Implements data model configuration through Data Annotations and Fluent API.

## Project Structure

- `Models`: Contains classes for data models.
- `Configuration`: Contains classes for model configuration using Fluent API.
- `Migrations`: Contains migrations for database management.


## Code Examples

### Data Annotations:

```csharp
public class Phone
{
    public int Ident { get; set; }
    
    [StringLength(50)]
    public string Name { get; set; }
    
    [Required]
    public int Price { get; set; }
    
    public int CompanyId { get; set; }
    public virtual Company Company { get; set; }
}
```
### Fluent API:
```csharp
internal class PhoneConfiguration : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.ToTable("Mobiles").HasKey(p => p.Ident);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
    }
}
```
### DbContext Configuration
The AppDbContext class configures the DbContext, including connection details and application of entity configurations.

```csharp
internal class AppDbContext : DbContext
{
    // ... (other properties)

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PhoneConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
    }
}
```
### Database Migrations

To manage database changes, migrations are used. First, the `Add-Migration` command is used to create a migration with a specified name (e.g., "InitialMigration"). After making changes to the data model or configuration, the `Update-Database` command is executed to apply the pending migrations and update the database schema accordingly.
