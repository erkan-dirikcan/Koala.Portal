using System.Data;
using System.Text;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Providers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Koala.Portal.Repository.Providers
{
    public class CrmSqlProvider : ICrmSqlProvider
    {
        private readonly ILogger<CrmSqlProvider> _logger;

        public CrmSqlProvider(ILogger<CrmSqlProvider> logger)
        {
            _logger = logger;
        }

        public Response<DataTable> SqlReader(string connection, string query)
        {

            try
            {
                var conn = new SqlConnection(connection);
                var cmd = new SqlCommand(query, conn);
                conn.Open();
                var da = new SqlDataAdapter(cmd);
                var res = new DataTable();

                da.Fill(res);
                conn.Close();
                da.Dispose();
                return Response<DataTable>.SuccessData(200, "Sorgu Başarıyla Çalıştırıldı", res);
            }
            catch (Exception ex)
            {
                _logger.LogError("Sorgu Çalıştırılırken Bir Sorunla Karşılaşıldı Hata :" + ex.Message);
                return Response<DataTable>.FailData(400, "Sorgu Çalıştırılırken Bir Sorunla Karşılaşıldı", ex.Message, true);
            }
        }

        public Response<string> WriteToSql(string connection, string query)
        {
            var cnn = new SqlConnection(connection);
            var cmd = new SqlCommand(query, cnn);
            try
            {
                cmd.Connection.Open();
                var res = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return Response<string>.SuccessData(200, "Sql Server Yazma İşlemi Başarılı", res.ToString());
            }
            catch (Exception ex)
            {
                return Response<string>.FailData(400, "Sql Server'a Yazma Sırasında Bir Sorunla Karşılaşıldı", ex.Message, true);
            }
        }

        public Response<string> SqlUpdate(string connection, string table, Dictionary<string, dynamic> queryParams, string condition)
        {
            try
            {
                var query = new StringBuilder("Update " + table + " set ");
                var i = 1;
                foreach (var item in queryParams)
                {
                    query.Append(item.Key);
                    query.Append(" = ");
                    Type unknown = item.Value.GetType();

                    if (unknown == typeof(string))
                    {
                        query.Append(" '" + item.Value + "'");
                    }
                    else if (unknown == typeof(bool))
                    {
                        query.Append(" " + (item.Value ? "1" : "0"));
                    }
                    else
                    {
                        query.Append(" " + item.Value);
                    }
                    if (i < queryParams.Count)
                    {
                        query.Append(",");
                    }
                    i++;
                }
                query.Append(" where " + condition);

                return WriteToSql(connection, query.ToString());

            }
            catch (Exception ex)
            {
                return Response<string>.FailData(400, "Sql Server Update İşlemi Sırasında Bir Sorunla Karşılaşıldı", ex.Message, true);
            }
        }

        public Response<string> SqlInsert(string connection, string table, Dictionary<string, dynamic> queryParams)
        {
            try
            {
                var sorgu = new StringBuilder("INSERT INTO " + table + " ");
                var cols = new StringBuilder("(");
                var vals = new StringBuilder("VALUES (");

                var i = 1;
                foreach (var item in queryParams)
                {
                    cols.Append(item.Key);

                    Type unknown = item.Value.GetType();

                    if (unknown == typeof(string))
                    {
                        vals.Append(" '" + item.Value + "'");
                    }
                    else if (unknown == typeof(bool))
                    {
                        vals.Append(" " + (item.Value ? "1" : "0"));
                    }
                    else
                    {
                        vals.Append(" " + item.Value);
                    }
                    if (i < queryParams.Count)
                    {
                        cols.Append(",");
                        vals.Append(",");
                    }
                    else
                    {
                        cols.Append(") ");
                        vals.Append(") ");
                    }
                    i++;
                }
                sorgu.Append(cols.ToString());
                sorgu.Append(vals.ToString());
                return WriteToSql(connection, sorgu.ToString());


            }
            catch (Exception ex)
            {
                return Response<string>.FailData(400, "Sql Server Insert İşlemi Sırasında Bir Sorunla Karşılaşıldı", ex.Message, true);
            }
        }

        public Response<string> CheckDatabaseExists(string connection)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("select 1", con);
                con.Open();
                var rowCount = cmd.ExecuteScalar();
                con.Close();
                return Response<string>.SuccessData(200,"Sql Server Bağlantısı Başarılı","Sql Server Bağlantısı Başarılı");
            }
            catch(Exception ex)
            {
                return Response<string>.FailData(200,"Sql Server Bağlantısı Başarısız",ex.Message,true);
            }
        }
    }
}
