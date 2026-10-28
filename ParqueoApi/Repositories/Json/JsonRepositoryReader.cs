using System.Text.Json;

namespace ParqueoApi.Repositories.Json;

internal static class JsonRepositoryReader
{
    public static async Task<IReadOnlyList<T>> LeerTodosAsync<T>(
        string contentRootPath,
        string fileName,
        CancellationToken cancellationToken)
    {
        var filePath = Path.Combine(contentRootPath, "Data", fileName);
        await using var stream = File.OpenRead(filePath);
        var records = await JsonSerializer.DeserializeAsync<List<T>>(stream, cancellationToken: cancellationToken);

        return records ?? throw new InvalidOperationException($"El archivo JSON '{filePath}' no contiene una lista válida.");
    }
}
