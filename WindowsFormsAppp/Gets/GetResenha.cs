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
    public partial class GetResenha : Form
    {
        public GetResenha()
        {
            InitializeComponent();
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Puts.PutReserva pagina = new WindowsFormsAppp.Puts.PutReserva();
            pagina.Show();
            this.Hide();
        }

        private void Criar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Posts.PostReserva pagina = new WindowsFormsAppp.Posts.PostReserva();
            pagina.Show();
            this.Hide();
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Deletes.DeleteReserva pagina = new WindowsFormsAppp.Deletes.DeleteReserva();
            pagina.Show();
            this.Hide();
        }
    }
}
