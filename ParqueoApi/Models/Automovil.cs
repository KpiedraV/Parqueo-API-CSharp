namespace ParqueoApi.Models;

public class Automovil
{
    public int Id { get; set; }
    public string Color { get; set; } = string.Empty;
    public int Anio { get; set; }
    public string Fabricante { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();
}
