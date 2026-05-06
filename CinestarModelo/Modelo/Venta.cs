namespace CinestarModelo.Modelo;
public class Venta
{
    public int idVenta { get; set; }
    public int idCliente { get; set; }
    public int idPelicula { get; set; }
    public int idSucursal { get; set; }
    public DateTime fechaVenta { get; set; }
    public int cantidadAsientos { get; set; }
    public double totalVentas { get; set; }
}
