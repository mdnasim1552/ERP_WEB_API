using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Reflection.PortableExecutable;

namespace ERP_WEB_API.DataAccess
{
    public class ProcessAccess:IProcessAccess
    {
        private readonly IDbConnection _dbConnection;
        public ProcessAccess(IDbConnection dbConnection)
        {
            _dbConnection=dbConnection;
        }

        public async Task<List<T>> GetAllAsync<T>(string SQLprocName, params SqlParameter[] parameters) where T : new()
        {
            try
            {
                List<T> resultList = new List<T>();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQLprocName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);
                using (SqlDataReader reader = await ExecuteReaderAsync(cmd))
                {
                    if (reader.HasRows)
                    {
                        
                        while (await reader.ReadAsync())
                        {
                            T instance = new T();
                            for (int inc = 0; inc < reader.FieldCount; inc++)
                            {
                                Type type = instance.GetType();
                                PropertyInfo prop = type.GetProperty(reader.GetName(inc));
                                prop.SetValue(instance, reader.GetValue(inc), null);
                            }
                            resultList.Add(instance);
                        }
                    }
                }
                    //SqlDataReader reader =await ExecuteReader(cmd);                          
                return resultList;
            }
            catch (Exception exp)
            {
                return null;
            }
        }
        public async Task<SqlDataReader> ExecuteReaderAsync(SqlCommand cmd)
        {
            if (_dbConnection is SqlConnection sqlConnection)
            {
                cmd.Connection = sqlConnection;
                cmd.CommandTimeout = 120;

                try
                {
                    if (sqlConnection.State != ConnectionState.Open)
                    {
                        await sqlConnection.OpenAsync();
                    }

                    SqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                    return reader;
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    return null;
                }
            }
            else
            {
                // Handle the case where _dbConnection is not of type SqlConnection
                return null;
            }
        }
        public async Task<bool> ExecuteTransactionalOperationAsync(string SQLprocName, params SqlParameter[] parameters)
        {
            try
            {
                if (_dbConnection is SqlConnection sqlConnection)
                {
                    if (_dbConnection.State != ConnectionState.Open)
                    {
                        await sqlConnection.OpenAsync();
                    }
                    using (var transaction = sqlConnection.BeginTransaction())
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = SQLprocName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parameters);
                        cmd.Connection = sqlConnection;
                        cmd.Transaction = transaction;
                        cmd.CommandTimeout = 120;
                        try
                        {
                            int affectedRows = await cmd.ExecuteNonQueryAsync();

                            if (affectedRows > 0)
                            {
                                // If execution was successful, commit the transaction
                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                // If no rows were affected, rollback the transaction
                                transaction.Rollback();
                                return false;
                            }
                        }
                        catch (Exception exp)
                        {
                            // Handle exceptions
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //public async Task<bool> UpdateAllAsync(string SQLprocName, params SqlParameter[] parameters)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = SQLprocName;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddRange(parameters);

        //        int affectedRows = await ExecuteCommandAsync(cmd);
        //        return affectedRows > 0;  // Check if any rows were affected
        //    }
        //    catch (Exception exp)
        //    {
        //        return false;
        //    }
        //}

        //public async Task<int> ExecuteCommandAsync(SqlCommand cmd)
        //{
        //    if (_dbConnection is SqlConnection sqlConnection)
        //    {
        //        cmd.Connection = sqlConnection;
        //        cmd.CommandTimeout = 120;

        //        try
        //        {
        //            if (sqlConnection.State != ConnectionState.Open)
        //            {
        //                await sqlConnection.OpenAsync();
        //            }
        //            int result= await cmd.ExecuteNonQueryAsync();
        //            return result;
        //        }
        //        catch (Exception ex)
        //        {
        //            // Handle exceptions
        //            return -1;  // Indicate failure
        //        }
        //    }

        //    // If _dbConnection is not of type SqlConnection
        //    return -1;  // Indicate failure
        //}

    }
}
