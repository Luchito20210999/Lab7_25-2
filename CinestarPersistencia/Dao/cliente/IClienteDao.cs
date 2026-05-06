using CinestarModelo.Modelo;

namespace CinestarPersistencia.Dao.cliente;

public interface IClienteDao : IPersistible<Cliente, int>
{
    int InsertarCliente(Cliente cliente);
}
