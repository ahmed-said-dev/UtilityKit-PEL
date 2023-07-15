using UtilityKit.Components.Pel.Application.Shared.Interfaces;
using UtilityKit.Components.Pel.Infrastrcuture.Constants;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;
using System.Diagnostics;
using G2Kit.Components.Identity.Core;
using System.Reflection.Metadata;

namespace UtilityKit.Components.Pel.Infrastrcuture;
public class PelDbContext : DbContext, IUnitOfWork
{
    #region --- Constructor
    public PelDbContext(DbContextOptions<PelDbContext> options) : base(options) { }
    #endregion

    #region --- Methods
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasPostgresExtension(PostgresExtensions.UUID_AUTOGENERATE);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder //TODO : Should to delete this before go to production 
         .LogTo(message => Debug.WriteLine(message))
         .EnableDetailedErrors();
    }
    #endregion

    #region --- Register Tables
   // public DbSet<ATLProject> ATLProjects { get; set; }
    #endregion
}