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
using WindowsFormsAppp.Deletes;

namespace WindowsFormsAppp.Gets.GetSubCarros
{
    public partial class GetCarro : Form
    {
        public GetCarro()
        {
            InitializeComponent();
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Puts.PutSubCarros.PutCarro pagina = new WindowsFormsAppp.Puts.PutSubCarros.PutCarro();
            pagina.Show();
            this.Hide();
        }

        private void Criar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Posts.PostSubCarros.PostCarro pagina = new WindowsFormsAppp.Posts.PostSubCarros.PostCarro();
            pagina.Show();
            this.Hide();
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Deletes.DeleteSubCarros.Deletecarro pagina = new WindowsFormsAppp.Deletes.DeleteSubCarros.Deletecarro();
            pagina.Show();
            this.Hide();
        }
    }
}
