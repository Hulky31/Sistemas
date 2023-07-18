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
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            ClienteColecao clientes = new ClienteColecao();
        
            clientes = clienteNegocio.ConsultarPorNome(textBox1.Text.ToString());

          
            dgwPrincipal.DataSource = clientes;
        }

      
    }
}
