using System.Data;

namespace GCB.Comum.Factories
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
