namespace ParqueoApi.Models;

public class Parqueo
{
    public int Id { get; set; }
    public string NombreProvincia { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public decimal PrecioPorHora { get; set; }
    public ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();
}
