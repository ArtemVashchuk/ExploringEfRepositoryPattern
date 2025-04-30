using Gatherly.Domain.Primitives;

namespace Gatherly.Domain.Repositories;

public interface IRepository<T>
    where T : AggregateRoot;