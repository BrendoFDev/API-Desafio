using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppp.Gets.GetSubCarros;

namespace WindowsFormsAppp.Gets
{
    public partial class SubCarro : Form
    {
        public SubCarro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Gets.GetSubCarros.GetCarro formPrincipal = new WindowsFormsAppp.Gets.GetSubCarros.GetCarro();
            formPrincipal.Show();
            this.Hide();
        }

        private void Carro_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Gets.GetSubCarros.GetCarro formPrincipal = new WindowsFormsAppp.Gets.GetSubCarros.GetCarro();
            formPrincipal.Show();
            this.Hide();
        }

        private void Marca_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Gets.GetSubCarros.GetMarca formPrincipal = new WindowsFormsAppp.Gets.GetSubCarros.GetMarca();
            formPrincipal.Show();
            this.Hide();
        }

        private void Modelo_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Gets.GetSubCarros.GetModelo formPrincipal = new WindowsFormsAppp.Gets.GetSubCarros.GetModelo();
            formPrincipal.Show();
            this.Hide();
        }
    }
}
