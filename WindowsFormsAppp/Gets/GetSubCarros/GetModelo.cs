using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Back.Models;
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

        private void GetModelo_Load(object sender, EventArgs e)
        {
            listaModelo.View = View.Details;
            listaModelo.FullRowSelect = true;

            listaModelo.Columns.Add("ID Marca", 80);
            listaModelo.Columns.Add("ID Modelo", 80);
            listaModelo.Columns.Add("Nome", 200);
        }
        private async Task PreencherColunasDaListView()
        {
            listaModelo.Items.Clear();

            string urlApiLocal = "https://localhost:7063/api/modelo";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonResponse = await client.GetStringAsync(urlApiLocal);
                    var opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    // Converte o JSON para a lista de objetos
                    List<Modelo> listaUsuarios = JsonSerializer.Deserialize<List<Modelo>>(jsonResponse, opcoes);

                    foreach (var usuario in listaUsuarios)
                    {

                        ListViewItem linha = new ListViewItem(usuario.MarcaId.ToString());
                        linha.SubItems.Add(usuario.Id.ToString());
                        linha.SubItems.Add(usuario.NomeModelo);
                        listaModelo.Items.Add(linha);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao preencher colunas: {ex.Message}");
                }
            }
        }
    }
}
