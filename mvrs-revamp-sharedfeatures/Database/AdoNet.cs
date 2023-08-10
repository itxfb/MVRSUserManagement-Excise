using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IAdoNet
    {
        //long ExecuteNonQuery(string Query, SqlParameter[] Parameters, string ReturnId);
        Task<long> ExecuteNonQuery(string Query, SqlParameter[] Parameters);
        object ExecuteScalar(string Query, SqlParameter[] Parameters);
        Task<DataSet> ExecuteUsingDataAdapter(string Query, SqlParameter[] Parameters);
    }

    public class AdoNet : IAdoNet
    {
        readonly string connectionString;
        readonly SqlConnection cn;

        public AdoNet(string connectionString)
        {
            this.connectionString = connectionString;
            this.cn = new SqlConnection(this.connectionString);
        }

        public async Task<DataSet> ExecuteUsingDataAdapter(string Query, SqlParameter[] Parameters)
        {
            DataSet ds = await Task.Factory.StartNew(() => 
            {
                SqlCommand cmd = new SqlCommand(Query, this.cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Query;
                cmd.CommandTimeout = 3000;

                if (Parameters != null)
                {
                    foreach (SqlParameter parameter in Parameters)
                    {
                        parameter.DbType = parameter.DbType;
                        parameter.ParameterName = parameter.ParameterName;
                        parameter.Value = parameter.Value;
                        cmd.Parameters.Add(parameter);
                    }
                }

                DataSet datSet = new DataSet();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(datSet);
                }

                return datSet;
            });

            return ds;
        }

        public long ExecuteNonQuery_0(string Query, SqlParameter[] Parameters)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(Query, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                if (Parameters != null)
                {
                    foreach (SqlParameter parameter in Parameters)
                    {
                        parameter.SqlDbType = parameter.SqlDbType;
                        parameter.ParameterName = parameter.ParameterName;
                        parameter.Value = parameter.Value;
                        cmd.Parameters.Add(parameter);
                    }
                }
                //string ReturnId;
                //cmd.Parameters.Add(@ReturnId, SqlDbType.Int).Direction = ParameterDirection.Output;
                //int a = cmd.ExecuteNonQuery();
                //string id = cmd.Parameters[@ReturnId].Value.ToString();
                //return Convert.ToInt64(id);

                var rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }
        public async Task<long> ExecuteNonQuery(string Query, SqlParameter[] Parameters)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(Query, cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    if (Parameters != null)
                    {
                        foreach (SqlParameter parameter in Parameters)
                        {
                            parameter.SqlDbType = parameter.SqlDbType;
                            parameter.ParameterName = parameter.ParameterName;
                            parameter.Value = parameter.Value;
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    var rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected;
                });
            }
            finally
            {
                cn.Close();
            }
        }

        public object ExecuteScalar(string Query, SqlParameter[] Parameters)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(Query, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                if (Parameters != null)
                {
                    foreach (SqlParameter parameter in Parameters)
                    {
                        parameter.SqlDbType = parameter.SqlDbType;
                        parameter.ParameterName = parameter.ParameterName;
                        parameter.Value = parameter.Value;
                        cmd.Parameters.Add(parameter);
                    }
                }
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }
    }

}
