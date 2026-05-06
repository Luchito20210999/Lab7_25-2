using CinestarModelo.Modelo;

namespace CinestarPersistencia.Dao.sucursal;

public interface ISucursalDao : IPersistible<Sucursal, int>
{//Siempre va con mayuscula la primera letra del metodo
    int InsertarSucursal(Sucursal sucursal);
}