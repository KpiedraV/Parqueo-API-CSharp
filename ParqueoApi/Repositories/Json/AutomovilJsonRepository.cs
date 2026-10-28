using ParqueoApi.Models;

namespace ParqueoApi.Repositories.Json;

public class AutomovilJsonRepository(string contentRootPath) : IAutomovilRepository
{
    public Task<IReadOnlyList<Automovil>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
    {
        return JsonRepositoryReader.LeerTodosAsync<Automovil>(contentRootPath, "Automoviles.json", cancellationToken);
    }
}
