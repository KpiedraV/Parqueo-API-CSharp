using ParqueoApi.Models;

namespace ParqueoApi.Repositories;

public interface IIngresoRepository
{
    Task<IReadOnlyList<Ingreso>> ObtenerTodosAsync(CancellationToken cancellationToken = default);
}
