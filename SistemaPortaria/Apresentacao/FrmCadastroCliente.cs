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
        AcaoNaTela AcaoNaTelaSelecionada;
        public FrmCadastroCliente(AcaoNaTela acaoNaTela, Cliente cliente)
        {
            InitializeComponent();

            AcaoNaTelaSelecionada = acaoNaTela;

            if (acaoNaTela.Equals(AcaoNaTela.Inserir))
            {
                this.Text = "Inserir Cliente";
                textBoxNome.Text = cliente.Nome;
                textBoxNumero.Text = cliente.Numero.ToString();
                textBoxCpf.Text = cliente.CPF;
                dateDataNascimento.MinDate = cliente.DataNascimento;
               
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

                textBoxCodigo.TabStop = false;
                textBoxNome.ReadOnly = true;
                textBoxNome.TabStop = false; 
                textBoxNumero.ReadOnly = true;
                textBoxNumero.TabStop = false;
                textBoxCpf.ReadOnly = true;
                textBoxCpf.TabStop = false;
                dateDataNascimento.Enabled = false;
                btnSalvar.Visible = false;
                btnCancelar.Text = "Fechar";
                btnCancelar.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (AcaoNaTelaSelecionada == AcaoNaTela.Inserir)
            {
                Cliente cliente = new Cliente();
                cliente.Nome = textBoxNome.Text;
                cliente.Numero = Convert.ToDecimal(textBoxNumero.Text);
                cliente.CPF = textBoxCpf.Text;
                cliente.DataNascimento = dateDataNascimento.Value;
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                string retorno = clienteNegocio.Inserir(cliente);

                try
                {
                    int IdCliente = Convert.ToInt32(retorno);

                    MessageBox.Show("Cliente Inserido com sucesso. Código:" + " " + IdCliente.ToString());
                    
                    this.DialogResult = DialogResult.Yes;
                }
                catch (Exception)
                {

                    MessageBox.Show("Não foi possível inserir. Detalhes:" + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.DialogResult = DialogResult.No;

                }
            }
            else if (AcaoNaTelaSelecionada == AcaoNaTela.Alterar)
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = Convert.ToInt32(textBoxCodigo.Text);
                cliente.Nome = textBoxNome.Text;
                cliente.Numero = Convert.ToDecimal(textBoxNumero.Text);
                cliente.CPF = textBoxCpf.Text;
                cliente.DataNascimento = dateDataNascimento.Value;
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                string retorno = clienteNegocio.Alterar(cliente);
                
                try
                {
                    int IdCliente = Convert.ToInt32(retorno);

                    MessageBox.Show("Cliente Alterado com sucesso. Código:" + " " + IdCliente.ToString());

                    this.DialogResult = DialogResult.Yes;
                }
                catch (Exception)
                {

                    MessageBox.Show("Não foi possível inserir. Detalhes:" + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.DialogResult = DialogResult.No;

                }


            }
        }
    }
}
