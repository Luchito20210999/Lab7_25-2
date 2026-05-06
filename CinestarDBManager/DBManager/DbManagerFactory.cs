namespace CinestarDBManager.DBManager;

public abstract class DbManagerFactory
{
    public abstract DbManager CrearDbManager(string connectionStringBase);
}
