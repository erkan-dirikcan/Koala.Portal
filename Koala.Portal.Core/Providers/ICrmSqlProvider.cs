using System.Data;
using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.Providers;

public interface ICrmSqlProvider
{
    Response<DataTable> SqlReader(string connection, string query);
    Response<string> WriteToSql(string connection,string query);
    Response<string> SqlUpdate(string connection,string table, Dictionary<string, dynamic> queryParams, string condition);
    Response<string> SqlInsert(string connection,string table, Dictionary<string, dynamic> queryParams);
    Response<string> CheckDatabaseExists(string connection);
}