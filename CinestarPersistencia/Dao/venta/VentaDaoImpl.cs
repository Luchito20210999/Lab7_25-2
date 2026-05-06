using CinestarModelo.Modelo;
using System.Data;
using System.Data.Common;

namespace CinestarPersistencia.Dao.venta;

public class VentaDaoImpl : DefaultBaseDao<Venta>, IVentaDao
{
    protected override DbCommand ComandoCrear(DbConnection conn, Venta modelo)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERTAR_VENTA";
        cmd.CommandType = CommandType.StoredProcedure;
        CrearParametro(cmd, "_id_venta", DbType.Int32);
        CrearParametro(cmd, "@_fid_cliente", modelo.idCliente);
        CrearParametro(cmd, "@_fid_pelicula", modelo.idPelicula);
        CrearParametro(cmd, "@_fid_sucursal", modelo.idSucursal);
        CrearParametro(cmd, "@_fecha_venta", modelo.fechaVenta);
        CrearParametro(cmd, "@_cantidad_asientos", modelo.cantidadAsientos);
        CrearParametro(cmd, "@_total_venta", modelo.totalVentas);
        return cmd;
    }

    public int InsertarVenta(Venta modelo)
    {
        return EjecutarComando(conn => EjecutarComandoCrear(conn, modelo));
    }

  /*  protected DbCommand ComandoInsertar(DbConnection conn, Venta modelo)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERTAR_VENTA";
        cmd.CommandType = CommandType.StoredProcedure;
        CrearParametro(cmd, "_id_venta", modelo.idVenta);
        CrearParametro(cmd, "@_fid_cliente", modelo.idCliente);
        CrearParametro(cmd, "@_fid_pelicula", modelo.idPelicula);
        CrearParametro(cmd, "@_fid_sucursal", modelo.idSucursal);
        CrearParametro(cmd, "@_fecha_venta", modelo.fechaVenta);
        CrearParametro(cmd, "@_cantidad_asientos", modelo.cantidadAsientos);
        CrearParametro(cmd, "@_total_venta", modelo.totalVentas);
        return cmd;
    }
  */
    protected override DbCommand ComandoActualizar(DbConnection conn, Venta modelo)
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
        cmd.CommandText = "SELECT * FROM venta;";
        return cmd;
    }

    protected override Venta MapearModelo(DbDataReader reader)
    {
        return new Venta
        {
            idVenta = reader.GetInt32(reader.GetOrdinal("id_venta")),
            idCliente = reader.GetInt32(reader.GetOrdinal("fid_cliente")),
            idPelicula = reader.GetInt32(reader.GetOrdinal("fid_pelicula")),
            idSucursal = reader.GetInt32(reader.GetOrdinal("fid_sucursal")),
            fechaVenta = reader.GetDateTime(reader.GetOrdinal("fecha_venta")),
            cantidadAsientos = reader.GetInt32(reader.GetOrdinal("cantidad_asientos")),
            totalVentas = reader.GetDouble(reader.GetOrdinal("total_venta"))
        };
    }
}
