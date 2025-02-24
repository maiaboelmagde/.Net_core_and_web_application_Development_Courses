using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;


namespace DAL
{
    public class DBManager
    {
        SqlConnection SqlCN;
        SqlCommand SqlCmd;
        SqlDataAdapter DA;
        DataTable Dt;
        public DBManager()
        {
            try
            {
                SqlCN = new();
                SqlCN.ConnectionString = ConfigurationManager.ConnectionStrings["PubsCN"].ConnectionString;
                SqlCmd = new(string.Empty, SqlCN);
                DA = new(SqlCmd);
                Dt = new();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }

        public DataTable ExecuteDataTable(string SPName)
        {
            try
            {
                SqlCmd.Parameters.Clear();
                Dt.Clear();

                SqlCmd.CommandText = SPName;

                DA.Fill(Dt);
                return Dt;

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return new();
        }
        public object ExecuteScaler(string SPName)
        {
            try
            {
                SqlCmd.Parameters.Clear();
                SqlCmd.CommandText = SPName;

                if (SqlCN.State == ConnectionState.Closed)
                    SqlCN.Open();

                return SqlCmd.ExecuteScalar();

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                SqlCN.Close();
            }
            return new();
        }
        public int ExecuteNonQuery(string SPName)
        {
            try
            {
                SqlCmd.Parameters.Clear();
                SqlCmd.CommandText = SPName;

                if (SqlCN.State == ConnectionState.Closed)
                    SqlCN.Open();

                return SqlCmd.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                SqlCN.Close();
            }
            return -1;
        }

        public object ExecuteScaler(string SPName, Dictionary<string, object> Parameters)
            => throw new NotImplementedException();

        public DataTable ExecuteDataTable(string SPName, Dictionary<string, object> Parameters)
            => throw new NotImplementedException();

        public int ExecuteNonQuery(string SPName, Dictionary<string, object> Parameters)
        {
            try
            {
                SqlCmd.Parameters.Clear();
                SqlCmd.CommandText = SPName;

                foreach (var Parameter in Parameters)
                    SqlCmd.Parameters.Add(new(Parameter.Key, Parameter.Value));

                if (SqlCN.State == ConnectionState.Closed)
                    SqlCN.Open();

                return SqlCmd.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                SqlCN.Close();
            }
            return -1;
        }
    }
}
