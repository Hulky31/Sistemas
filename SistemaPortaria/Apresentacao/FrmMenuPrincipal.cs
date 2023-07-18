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

        private void menu_Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menu_Cliente_Click(object sender, EventArgs e)
        {
            FrmClienteCadastrar frmClienteCadastrar = new FrmClienteCadastrar();

            frmClienteCadastrar.MdiParent = this;

            frmClienteCadastrar.Show();
        }

      
    }
}
