using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppp.Usuario;

namespace WindowsFormsAppp.Gets
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void Carro_Click(object sender, EventArgs e)
        {
            SubCarro novaPagina = new SubCarro();


            novaPagina.Show();
            this.Hide();
        }

        private void Cliente_Click(object sender, EventArgs e)
        {
            GetCliente novaPagina = new GetCliente();


            novaPagina.Show();
            this.Hide();
        }

        private void Reserva_Click(object sender, EventArgs e)
        {
            GetResenha novaPagina = new GetResenha();


            novaPagina.Show();
            this.Hide();
        }
    }
}
