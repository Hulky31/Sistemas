using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoBancoDados
{
    public class AcessoDadosSqlServer
    {
        public SqlConnection CriarConexao()
        {
            return new SqlConnection(Properties.Settings.Default.stringConexao);
        }

        SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        public void AdicionaParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));

        }
        public object ExecutarManipulacao(CommandType commandType, string nomeStoredProcedureOutextoSql) 
        {
            SqlConnection sqlConnection = CriarConexao();
            
            sqlConnection.Open();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandType = commandType;
            sqlCommand.CommandText = nomeStoredProcedureOutextoSql;
            sqlCommand.CommandTimeout = 7200;

            foreach (SqlParameter sqlParameter in sqlParameterCollection)
            {
                sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
            }

            return sqlCommand.ExecuteScalar();
        }
        public DataTable ExecutarConsulta(CommandType commandType, string nomeStoredProcedureOutextoSql)
        {
            SqlConnection sqlConnection = CriarConexao();
            
            sqlConnection.Open();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandType = commandType;
            sqlCommand.CommandText = nomeStoredProcedureOutextoSql;
            sqlCommand.CommandTimeout = 7200;

            

            foreach (SqlParameter sqlParameter in sqlParameterCollection)
            {
                sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
            }


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }

    }

}
