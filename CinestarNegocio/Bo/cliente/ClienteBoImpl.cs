using CinestarModelo.Modelo;
using CinestarPersistencia.Dao.cliente;

namespace CinestarNegocio.Bo.cliente;

public class ClienteBoImpl : BaseBo, IClienteBo
{
    private readonly IClienteDao _clienteDao = new ClienteDaoImpl();

    public List<Cliente> Listar() => _clienteDao.LeerTodos();

    public Cliente? Obtener(int id)
    {
        ValidarIdPositivo(id, "id_cliente");
        return _clienteDao.Leer(id);
    }

    public void Eliminar(int id)
    {
        ValidarIdPositivo(id, "id_cliente");
        if (!_clienteDao.Eliminar(id))
        {
            throw new InvalidOperationException($"No se pudo eliminar el producto con id: {id}");
        }
    }

    public void Guardar(Cliente modelo, Estado estado)
    {
        _ = modelo ?? throw new ArgumentNullException(nameof(modelo));
        if (estado == Estado.Nuevo)
        {
            var id = _clienteDao.Crear(modelo);
            if (id <= 0)
            {
                throw new InvalidOperationException("No se pudo crear el producto");
            }
            modelo.id = id;
            return;
        }

        if (estado == Estado.Modificado)
        {
            ValidarIdPositivo(modelo.id, "id del producto");
            if (!_clienteDao.Actualizar(modelo))
            {
                throw new InvalidOperationException($"No se pudo actualizar el producto con id: {modelo.id}");
            }
            return;
        }

        throw new ArgumentException($"Estado no soportado en guardar: {estado}");
    }
}