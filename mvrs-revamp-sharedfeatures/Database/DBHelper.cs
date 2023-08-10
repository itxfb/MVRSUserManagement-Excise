using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Database
{
    public interface IDBHelper
    {
        Task<DataSet> GetDataSetByStoredProcedure(string spName, Dictionary<string, object> paramDict);
        DataTable GetDataTableByStoredProcedure(string spName, Dictionary<string, object> paramDict);
    }

    public class DBHelper : IDBHelper
    {
        private SqlConnection sqlConnection;
        readonly string connectionstr;

        public DBHelper(string connectionstr)
        {
            this.connectionstr = connectionstr;
        }

        public async Task<DataSet> GetDataSetByStoredProcedure(string spName, Dictionary<string, object> paramDict)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (SqlConnection con = new SqlConnection(connectionstr))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con) { CommandType = CommandType.StoredProcedure })
                    {
                        if (paramDict != null && paramDict.Count > 0)
                        {
                            foreach (KeyValuePair<string, object> param in paramDict)
                            {
                                //cmd.Parameters.AddWithValue(param.Key, param.Value);

                                SqlParameter parameter = new SqlParameter();
                                parameter.ParameterName = param.Key;

                                if (param.Value is DataTable)
                                { 
                                    parameter.SqlDbType = SqlDbType.Structured;
                                }

                                if (param.Value is null)
                                {
                                    parameter.Value = DBNull.Value;
                                }
                                else
                                {
                                    parameter.Value = param.Value;
                                }

                                cmd.Parameters.Add(parameter);
                            }
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandTimeout = 0;
                            con.Open();
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            con.Close();
                            return ds;
                        }
                    }
                }
            });
        }

        public DataTable GetDataTableByStoredProcedure(string spName, Dictionary<string, object> paramDict)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstr))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con) { CommandType = CommandType.StoredProcedure })
                    {
                        if (paramDict != null && paramDict.Count > 0)
                        {
                            foreach (KeyValuePair<string, object> param in paramDict)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandTimeout = 10000000;
                            con.Open();
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            con.Close();
                            return ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
