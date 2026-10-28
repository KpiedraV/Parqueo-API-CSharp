namespace ParqueoApi.Models;

public class Ingreso
{
    public int Consecutivo { get; set; }
    public int ParqueoId { get; set; }
    public int AutomovilId { get; set; }
    public DateTime FechaHoraEntrada { get; set; }
    public DateTime? FechaHoraSalida { get; set; }
    public Parqueo Parqueo { get; set; } = null!;
    public Automovil Automovil { get; set; } = null!;
}
