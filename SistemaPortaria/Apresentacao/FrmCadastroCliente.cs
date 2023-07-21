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
    public partial class FrmCadastroCliente : Form
    {
        public FrmCadastroCliente(AcaoNaTela acaoNaTela, Cliente cliente)
        {
            InitializeComponent();

            if (acaoNaTela.Equals(AcaoNaTela.Inserir))
            {
                this.Text = "Inserir Cliente";
                textBoxNome.Text = cliente.Nome;
                textBoxNumero.Text = cliente.Numero.ToString();
                textBoxCpf.Text = cliente.CPF;
                dateDataNascimento.Value = cliente.DataNascimento;
               
            }
            else if (acaoNaTela.Equals(AcaoNaTela.Alterar))
            {
                this.Text = "Alterar Cliente";
                textBoxCodigo.Text = cliente.IdCliente.ToString();
                textBoxNome.Text = cliente.Nome;
                textBoxNumero.Text = cliente.Numero.ToString();
                textBoxCpf.Text = cliente.CPF;
                dateDataNascimento.Value = cliente.DataNascimento;
            }
            else if (acaoNaTela.Equals(AcaoNaTela.Consultar))
            {
                this.Text = "Consultar Cliente";
                textBoxCodigo.Text = cliente.IdCliente.ToString();
                textBoxNome.Text = cliente.Nome;
                textBoxNumero.Text = cliente.Numero.ToString();
                textBoxCpf.Text = cliente.CPF;
                dateDataNascimento.Value = cliente.DataNascimento;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            
        }
    }
}
