using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;
using ObjetoTransferencia;
using System.Data;

namespace Negocios
{
    public class ClienteNegocio
    {
        AcessoDadosSqlServer AcessoDadosSqlserver = new AcessoDadosSqlServer();

        public string Inserir(Cliente cliente)
        {
            AcessoDadosSqlserver.LimparParametros();
            AcessoDadosSqlserver.AdicionaParametros("@Nome", cliente.Nome);
            AcessoDadosSqlserver.AdicionaParametros("@Numero", cliente.Numero);
            AcessoDadosSqlserver.AdicionaParametros("@CPF", cliente.CPF);
            AcessoDadosSqlserver.AdicionaParametros("@Datanascimento", cliente.DataNascimento);
            string IdCliente = AcessoDadosSqlserver.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteInserir").ToString();

            return IdCliente; 
        }
        public string Alterar(Cliente cliente)
        {
            AcessoDadosSqlserver.LimparParametros();
            AcessoDadosSqlserver.AdicionaParametros("IdCliente", cliente.IdCliente);
            AcessoDadosSqlserver.AdicionaParametros("@Nome", cliente.Nome);
            AcessoDadosSqlserver.AdicionaParametros("@Numero", cliente.Numero);
            AcessoDadosSqlserver.AdicionaParametros("@CPF", cliente.CPF);
            AcessoDadosSqlserver.AdicionaParametros("@DaTaNascimento", cliente.DataNascimento);
            string IdCliente = AcessoDadosSqlserver.ExecutarManipulacao(CommandType.StoredProcedure, "uspCleinteAlterar").ToString();

            return IdCliente;
        }
        public string Excluir(Cliente cliente)
        {
            AcessoDadosSqlserver.LimparParametros();
            AcessoDadosSqlserver.AdicionaParametros("IdCliente", cliente.IdCliente);
            string IdCliente = AcessoDadosSqlserver.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteExcluir").ToString();

            return IdCliente;
        } 
        public ClienteColecao ConsultarPorNome(string Nome)
        {
            ClienteColecao clienteColecao = new ClienteColecao();
            AcessoDadosSqlserver.LimparParametros();
           
            AcessoDadosSqlserver.AdicionaParametros("@Nome", Nome);
            DataTable dataTableCliente = AcessoDadosSqlserver.ExecutarConsulta(CommandType.StoredProcedure, "uspClienteConsultarPorNome");


            foreach (DataRow dataRow in dataTableCliente.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = Convert.ToInt32(dataRow["IdCliente"]);
                cliente.Nome = Convert.ToString(dataRow["Nome"]);
                cliente.Numero = Convert.ToDecimal(dataRow["Numero"]);
                cliente.CPF = Convert.ToString(dataRow["CPF"]);
                cliente.DataNascimento = Convert.ToDateTime(dataRow["DataNascimento"]);

                clienteColecao.Add(cliente);
      
            }
            return clienteColecao;
            

        }
        public ClienteColecao ConsultarPorID(int IdCliente)
        {
            ClienteColecao clienteColecao = new ClienteColecao();
            AcessoDadosSqlserver.LimparParametros();

            AcessoDadosSqlserver.AdicionaParametros("@IdCliente", IdCliente);
            DataTable dataTableCliente = AcessoDadosSqlserver.ExecutarConsulta(CommandType.StoredProcedure, "uspConsultarPorID");


            foreach (DataRow dataRow in dataTableCliente.Rows)
            {
                Cliente cliente = new Cliente();

                cliente.IdCliente = Convert.ToInt32(dataRow["IdCliente"]);
                cliente.Nome = Convert.ToString(dataRow["Nome"]);
                cliente.Numero = Convert.ToDecimal(dataRow["Numero"]);
                cliente.CPF = Convert.ToString(dataRow["CPF"]);
                cliente.DataNascimento = Convert.ToDateTime(dataRow["Datanascimento"]);

                
                clienteColecao.Add(cliente);
            }

            return clienteColecao;
        }

    }
}
