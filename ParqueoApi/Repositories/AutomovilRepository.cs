using Microsoft.EntityFrameworkCore;
using ParqueoApi.Data;
using ParqueoApi.Models;

namespace ParqueoApi.Repositories;

public class AutomovilRepository(ParqueoDbContext dbContext) : IAutomovilRepository
{
    public async Task<IReadOnlyList<Automovil>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Automoviles.AsNoTracking().ToListAsync(cancellationToken);
    }
}
