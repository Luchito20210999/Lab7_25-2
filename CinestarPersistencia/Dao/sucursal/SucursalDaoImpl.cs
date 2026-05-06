using CinestarModelo.Modelo;
using System.Data;
using System.Data.Common;

namespace CinestarPersistencia.Dao.sucursal;

public class SucursalDaoImpl : DefaultBaseDao<Sucursal>, ISucursalDao
{
    protected override DbCommand ComandoCrear(DbConnection conn, Sucursal modelo)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERTAR_SUCURSAL";
        cmd.CommandType = CommandType.StoredProcedure;
        CrearParametro(cmd, "_id_sucursal", DbType.Int32);
        CrearParametro(cmd, "@_nombre_sucursal", modelo.nombre);
        return cmd;
    }
    //Lo que me piden
    public int InsertarSucursal(Sucursal modelo)
    {
        return EjecutarComando(conn => EjecutarComandoCrear(conn, modelo));
    }

    protected override DbCommand ComandoActualizar(DbConnection conn, Sucursal modelo)
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
        cmd.CommandText = "SELECT * FROM sucursal;";
        return cmd;
    }

    protected override Sucursal MapearModelo(DbDataReader reader)
    {
        return new Sucursal
        {
            id = reader.GetInt32(reader.GetOrdinal("id_sucursal")),
            nombre = reader.GetString(reader.GetOrdinal("nombre_sucursal")),
        };
    }
}
