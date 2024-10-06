using FastAcademy.Application.Abstractions.Services;
using Microsoft.EntityFrameworkCore;

namespace FastAcademy.Persistence;

public sealed class FastAcademyDbContext : DbContext, IFastAcademyDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(PersistenceExtensions.Assembly);
    }
}