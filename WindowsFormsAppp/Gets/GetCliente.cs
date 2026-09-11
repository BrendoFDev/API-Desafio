using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppp.Gets
{
    public partial class GetCliente : Form
    {
        public GetCliente()
        {
            InitializeComponent();
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Puts.PutCliente pagina = new WindowsFormsAppp.Puts.PutCliente();
            pagina.Show();
            this.Hide();
        }

        private void Criar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Posts.SubCarros.PostCliente pagina = new WindowsFormsAppp.Posts.SubCarros.PostCliente();
            pagina.Show();
            this.Hide();
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Deletes.DeleteCliente pagina = new WindowsFormsAppp.Deletes.DeleteCliente();
            pagina.Show();
            this.Hide();
        }
    }
}
