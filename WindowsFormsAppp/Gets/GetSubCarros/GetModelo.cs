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
    public partial class GetModelo : Form
    {
        public GetModelo()
        {
            InitializeComponent();
        }

        private void Criar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Posts.SubCarros.PostModelo pagina = new WindowsFormsAppp.Posts.SubCarros.PostModelo();
            pagina.Show();
            this.Hide();
        }
        
        private void Atualizar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Puts.PutSubCarros.PutModelo pagina = new WindowsFormsAppp.Puts.PutSubCarros.PutModelo();
            pagina.Show();
            this.Hide();
        }

        

        private void Deletar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Deletes.DeleteSubCarros.DeleteModelo pagina = new WindowsFormsAppp.Deletes.DeleteSubCarros.DeleteModelo();
            pagina.Show();
            this.Hide();
        }
    }
}
