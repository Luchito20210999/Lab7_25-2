using CinestarModelo.Modelo;

namespace CinestarPersistencia.Dao.venta;

public interface IVentaDao : IPersistible<Venta, int>
{
    int InsertarVenta(Venta venta);
}