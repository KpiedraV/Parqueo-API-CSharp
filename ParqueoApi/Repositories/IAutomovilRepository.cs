using ParqueoApi.Models;

namespace ParqueoApi.Repositories;

public interface IAutomovilRepository
{
    Task<IReadOnlyList<Automovil>> ObtenerTodosAsync(CancellationToken cancellationToken = default);
}
