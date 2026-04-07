using System.Data;

namespace LearnDapperPostgres.Data
{
    public interface IDatabaseService
    {
       IDbConnection GetConnection();
    }
}
