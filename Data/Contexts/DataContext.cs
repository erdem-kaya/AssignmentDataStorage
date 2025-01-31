using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<CompanyEntity> Companies { get; set; }
    public DbSet<ContactPersonEntity> ContactPersons { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<CustomerTypeEntity> CustomerTypes { get; set; }
    public DbSet<EmployeeEntity> Employees { get; set; }
    public DbSet<ProjectEmployeeEntity> ProjectEmployees { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<StatusTransitionEntity> StatusTransitions { get; set; }
    public DbSet<StatusTypeEntity> StatusTypes { get; set; }
    public DbSet<UnitEntity> Units { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //ChatGPT hjälpte mig att skapa denna kod

        modelBuilder.Entity<ProjectEmployeeEntity>()
        .HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

        modelBuilder.Entity<ProjectEmployeeEntity>()
            .HasOne(pe => pe.Project)
            .WithMany(p => p.ProjectEmployees)
            .HasForeignKey(pe => pe.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEmployeeEntity>()
            .HasOne(pe => pe.Employee)
            .WithMany()
            .HasForeignKey(pe => pe.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<StatusTransitionEntity>()
            .HasOne(st => st.FromStatus)
            .WithMany()
            .HasForeignKey(st => st.FromStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StatusTransitionEntity>()
            .HasOne(st => st.ToStatus)
            .WithMany()
            .HasForeignKey(st => st.ToStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
