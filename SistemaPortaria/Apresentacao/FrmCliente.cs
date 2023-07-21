using Negocios;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmClienteCadastrar : Form
    {
        public FrmClienteCadastrar()
        {
            InitializeComponent();
            dgwPrincipal.AutoGenerateColumns = false;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
           
        }
        public void AtualizarGrid()
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            ClienteColecao clientes = new ClienteColecao();

            clientes = clienteNegocio.ConsultarPorNome(textBox1.Text.ToString());

            dgwPrincipal.DataSource = null;
            dgwPrincipal.DataSource = clientes;

            dgwPrincipal.Update();
            dgwPrincipal.Refresh();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            
            
                if (dgwPrincipal.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Nenhum cliente Selecionado");

                    return;
                }
                DialogResult result = MessageBox.Show("Tem certeza", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                Cliente clienteSelcionado = (dgwPrincipal.SelectedRows[0].DataBoundItem as Cliente);
                
                string retorno = clienteNegocio.Excluir(clienteSelcionado);
                
            try 
            {
                int IdCliente = Convert.ToInt32(retorno);
                MessageBox.Show("Cliente excluido com sucesso", "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Information);
                AtualizarGrid();

            }catch
            {
                MessageBox.Show("Não foi possível excluir. Detalhes:" + retorno, "Erro", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            FrmCadastroCliente frmCadastroCliente = new FrmCadastroCliente(AcaoNaTela.Inserir, cliente);
            DialogResult dialogResult = frmCadastroCliente.ShowDialog();
            
            if (dialogResult == DialogResult.Yes )
            {
                AtualizarGrid();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            if (dgwPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente Selecionado");

                return;
            }
          
            Cliente clienteSelcionado = (dgwPrincipal.SelectedRows[0].DataBoundItem as Cliente);

            FrmCadastroCliente frmCadastroCliente = new FrmCadastroCliente(AcaoNaTela.Alterar,clienteSelcionado);

            DialogResult dialogResult = frmCadastroCliente.ShowDialog();

            if (dialogResult== DialogResult.Yes)
            {
                AtualizarGrid();
            }


        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            if (dgwPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente Selecionado");

                return;
            }
          
            Cliente clienteSelcionado = (dgwPrincipal.SelectedRows[0].DataBoundItem as Cliente);

            FrmCadastroCliente frmCadastroCliente = new FrmCadastroCliente(AcaoNaTela.Consultar, clienteSelcionado);

            frmCadastroCliente.ShowDialog();

        }
    }
}
