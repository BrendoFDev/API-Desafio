using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppp.Posts;

namespace WindowsFormsAppp.Gets.GetSubCarros
{
    public partial class GetMarca : Form
    {
        public GetMarca()
        {
            InitializeComponent();
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Puts.PutSubCarros.PutMarca pagina = new WindowsFormsAppp.Puts.PutSubCarros.PutMarca();
            pagina.Show();
            this.Hide();
        }

        private void Criar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Posts.SubCarros.PostMarca pagina = new WindowsFormsAppp.Posts.SubCarros.PostMarca();
            pagina.Show();
            this.Hide();
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Deletes.DeleteSubCarros.DeleteMarca pagina = new WindowsFormsAppp.Deletes.DeleteSubCarros.DeleteMarca();
            pagina.Show();
            this.Hide();
        }
    }
}
