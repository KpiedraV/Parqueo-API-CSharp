using ParqueoApi.Models;

namespace ParqueoApi.Repositories.Json;

public class ParqueoJsonRepository(string contentRootPath) : IParqueoRepository
{
    public Task<IReadOnlyList<Parqueo>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
    {
        return JsonRepositoryReader.LeerTodosAsync<Parqueo>(contentRootPath, "Parqueos.json", cancellationToken);
    }
}
