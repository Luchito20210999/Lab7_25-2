
using System.Data.Common;

namespace CinestarPersistencia.Dao;

public delegate T ComandoDao<out T>(DbConnection connection);
