using CinestarModelo.Modelo;

namespace CinestarPersistencia.Dao.pelicula;

interface IPeliculaDao : IPersistible<Pelicula, int>
{
    int InsertarPelicula(Pelicula pelicula);
}
