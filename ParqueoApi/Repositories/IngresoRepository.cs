using Microsoft.EntityFrameworkCore;
using ParqueoApi.Data;
using ParqueoApi.Models;

namespace ParqueoApi.Repositories;

public class IngresoRepository(ParqueoDbContext dbContext) : IIngresoRepository
{
    public async Task<IReadOnlyList<Ingreso>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Ingresos.AsNoTracking().ToListAsync(cancellationToken);
    }
}
