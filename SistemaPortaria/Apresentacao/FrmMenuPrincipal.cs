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
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void menuCliente_Click(object sender, EventArgs e)
        {
            FrmClienteCadastrar frmClienteCadastrar = new FrmClienteCadastrar();

            frmClienteCadastrar.Parent = this;

            frmClienteCadastrar.Show();
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
