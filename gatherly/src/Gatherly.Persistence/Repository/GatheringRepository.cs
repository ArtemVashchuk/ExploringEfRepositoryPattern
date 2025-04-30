using Gatherly.Domain.Entities;
using Gatherly.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gatherly.Persistence.Repository;

internal sealed class GatheringRepository(ApplicationDbContext context) : IGatheringRepository
{
    public async Task<Gathering?> GetByIdWithCreatorAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Set<Gathering>()
            .Include(g => g.Creator)
            .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
    }

    public async Task<Gathering?> GetByIdWithInvitationsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Set<Gathering>()
            .Include(g => g.Invitations)
            .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
    }

    public void Add(Gathering gathering) =>
        context.Set<Gathering>().Add(gathering);

    public void Remove(Gathering gathering) =>
        context.Set<Gathering>().Remove(gathering);
}