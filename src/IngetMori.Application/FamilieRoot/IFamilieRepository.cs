using IngetMori.Domain.Core.ValueObjects.Keys;
using IngetMori.Domain.FamilieRoot;

namespace IngetMori.Application.FamilieRoot;
public interface IFamilieRepository
{
    Task<IEnumerable<Familie>> GetAllFamiliesAsync(CancellationToken cancellationToken = default);
    Task<Familie?> GetFamilieByIdAsync(FamilieId id, CancellationToken cancellationToken = default);
    Task InsertFamilieAsync(Familie familie, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}