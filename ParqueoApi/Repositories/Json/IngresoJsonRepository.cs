using ParqueoApi.Models;

namespace ParqueoApi.Repositories.Json;

public class IngresoJsonRepository(string contentRootPath) : IIngresoRepository
{
    public Task<IReadOnlyList<Ingreso>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
    {
        return JsonRepositoryReader.LeerTodosAsync<Ingreso>(contentRootPath, "Ingresos.json", cancellationToken);
    }
}
