using ParqueoApi.Models;

namespace ParqueoApi.Repositories;

public interface IParqueoRepository
{
    Task<IReadOnlyList<Parqueo>> ObtenerTodosAsync(CancellationToken cancellationToken = default);
}
