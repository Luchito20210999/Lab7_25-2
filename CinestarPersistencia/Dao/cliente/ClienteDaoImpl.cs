using CinestarModelo.Modelo;
using System.Data;
using System.Data.Common;

namespace CinestarPersistencia.Dao.cliente;

public class ClienteDaoImpl : DefaultBaseDao<Cliente>, IClienteDao
{
    protected override DbCommand ComandoCrear(DbConnection conn, Cliente modelo)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERTAR_CLIENTE";
        cmd.CommandType = CommandType.StoredProcedure;
        CrearParametro(cmd, "_id_cliente", DbType.Int32);
        CrearParametro(cmd, "@_nombre_cliente", modelo.nombre);
        CrearParametro(cmd, "@_apellido_cliente", modelo.apellido);
        CrearParametro(cmd, "@_email_cliente", modelo.email);

        return cmd;
    }
    //Lo que me piden
    public int InsertarCliente(Cliente modelo)
    {
        return EjecutarComando(conn => EjecutarComandoCrear(conn, modelo));
    }

    protected override DbCommand ComandoActualizar(DbConnection conn, Cliente modelo)
    {
        throw new NotImplementedException("Not supported yet.");
    }

    protected override DbCommand ComandoEliminar(DbConnection conn, int id)
    {
        throw new NotImplementedException("Not supported yet.");
    }

    protected override DbCommand ComandoLeer(DbConnection conn, int id)
    {
        throw new NotImplementedException("Not supported yet.");
    }

    protected override DbCommand ComandoLeerTodos(DbConnection conn)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM cliente;";
        return cmd;
    }

    protected override Cliente MapearModelo(DbDataReader reader)
    {
        return new Cliente
        {
            id = reader.GetInt32(reader.GetOrdinal("id_cliente")),
            nombre = reader.GetString(reader.GetOrdinal("nombre_cliente")),
            apellido = reader.GetString(reader.GetOrdinal("apellido_cliente")),
            email = reader.GetString(reader.GetOrdinal("email_cliente")),
        };
    }
}
