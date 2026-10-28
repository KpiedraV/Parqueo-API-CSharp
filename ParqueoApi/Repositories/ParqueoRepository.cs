using Microsoft.EntityFrameworkCore;
using ParqueoApi.Data;
using ParqueoApi.Models;

namespace ParqueoApi.Repositories;

public class ParqueoRepository(ParqueoDbContext dbContext) : IParqueoRepository
{
    public async Task<IReadOnlyList<Parqueo>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Parqueos.AsNoTracking().ToListAsync(cancellationToken);
    }
}
