using CinestarModelo.Modelo;
using System.Data;
using System.Data.Common;

namespace CinestarPersistencia.Dao.pelicula;

public class PeliculaDaoImpl : DefaultBaseDao<Pelicula>, IPeliculaDao
{
    protected override DbCommand ComandoCrear(DbConnection conn, Pelicula modelo)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERTAR_PELICULA";
        cmd.CommandType = CommandType.StoredProcedure;
        CrearParametro(cmd, "_id_pelicula", DbType.Int32);
        CrearParametro(cmd, "@_nombre_pelicula", modelo.nombre);
        CrearParametro(cmd, "@_genero_pelicula", modelo.genero);

        return cmd;
    }

    public int InsertarPelicula(Pelicula modelo)
    {
        return EjecutarComando(conn => EjecutarComandoCrear(conn, modelo));
    }

    /*  protected DbCommand ComandoInsertar(DbConnection conn, Pelicula modelo)
      {
          var cmd = conn.CreateCommand();
          cmd.CommandText = "INSERTAR_PELICULA";
          cmd.CommandType = CommandType.StoredProcedure;
          CrearParametro(cmd, "_id_pelicula", DbType.Int32);
          CrearParametro(cmd, "@_nombre_pelicula", modelo.nombre);
          CrearParametro(cmd, "@_genero_pelicula", modelo.genero);

          return cmd;
      }
    */
    protected override DbCommand ComandoActualizar(DbConnection conn, Pelicula modelo)
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
        cmd.CommandText = "SELECT * FROM pelicula;";
        return cmd;
    }

    protected override Pelicula MapearModelo(DbDataReader reader)
    {
        return new Pelicula
        {
            id = reader.GetInt32(reader.GetOrdinal("id_pelicula")),
            nombre = reader.GetString(reader.GetOrdinal("nombre_pelicula")),
            genero = Enum.Parse<GeneroPelicula>(reader.GetString(reader.GetOrdinal("genero_pelicula")))
        };
    }
}