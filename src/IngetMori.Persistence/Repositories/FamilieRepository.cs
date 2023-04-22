using IngetMori.Application.Common.Abstractions.Services;
using IngetMori.Domain.Core.ValueObjects.Keys;
using IngetMori.Domain.FamilieRoot;
using Microsoft.EntityFrameworkCore;
using IngetMori.Application.FamilieRoot;

namespace IngetMori.Persistence.Repositories;
public class FamilieRepository : IFamilieRepository
{
    private readonly IDbContext _dbContext;

    public FamilieRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Familie>> GetAllFamiliesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Families
                //.Where(f => f.Leden != null && f.Leden.Any(lid => !lid.DeletionInfo.IsDeleted))
                .Where(f => !f.DeletionInfo.IsDeleted)
                .ToListAsync(cancellationToken);
    }

    public async Task<Familie?> GetFamilieByIdAsync(FamilieId id, CancellationToken cancellationToken = default) =>
        await _dbContext.Families.FirstOrDefaultAsync(fam => fam.Id == id, cancellationToken: cancellationToken);

    public async Task InsertFamilieAsync(Familie familie, CancellationToken cancellationToken = default)
    {
        _dbContext.Families.Add(familie);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.SaveChangesAsync(cancellationToken);
}
