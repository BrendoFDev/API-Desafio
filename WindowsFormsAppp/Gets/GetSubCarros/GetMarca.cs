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
//using WindowsFormsAppp.Models;
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
           
        }

        private void Criar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Posts.SubCarros.PostMarca pagina = new WindowsFormsAppp.Posts.SubCarros.PostMarca();
            pagina.Show();
           
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Deletes.DeleteSubCarros.DeleteMarca pagina = new WindowsFormsAppp.Deletes.DeleteSubCarros.DeleteMarca();
            pagina.Show();
           
        }

        private void GetMarca_Load(object sender, EventArgs e)
        {
            listaMarca.View = View.Details;
            listaMarca.FullRowSelect = true;

            listaMarca.Columns.Add("ID Marca", 80);
            listaMarca.Columns.Add("Nome", 200);
        }
        private async Task PreencherColunasDaListView()
        {
            listaMarca.Items.Clear();

            string urlApiLocal = "https://localhost:7063/api/marca";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonResponse = await client.GetStringAsync(urlApiLocal);
                    var opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    // Converte o JSON para a lista de objetos
                    List<Marca> listaUsuarios = JsonSerializer.Deserialize<List<Marca>>(jsonResponse, opcoes);

                    foreach (var usuario in listaUsuarios)
                    {

                        ListViewItem linha = new ListViewItem(usuario.Id.ToString());
                        linha.SubItems.Add(usuario.NomeMarca);
                        listaMarca.Items.Add(linha);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao preencher colunas: {ex.Message}");
                }
            }
        }

        private void Voltar_Click(object sender, EventArgs e)
        {
            SubCarro pagina = new SubCarro();
            pagina.Show();
            this.Hide();
        }
    }
}
