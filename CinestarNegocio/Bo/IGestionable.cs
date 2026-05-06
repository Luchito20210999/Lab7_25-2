
using CinestarModelo.Modelo;

namespace CinestarNegocio.Bo;
public interface IGestionable<M>
{
    List<M> Listar();
    M? Obtener(int id);
    void Eliminar(int id);
    void Guardar(M modelo, Estado estado);
}
