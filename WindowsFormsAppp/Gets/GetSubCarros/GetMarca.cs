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
using Back.DTO_s;
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

        private async void GetMarca_Load(object sender, EventArgs e)
        {
            listaMarca.View = View.Details;
            listaMarca.FullRowSelect = true;
            listaMarca.GridLines = true;

            listaMarca.Columns.Add("ID Marca", 80);
            listaMarca.Columns.Add("Nome", 200);

            await PreencherColunasDaListView();


        }
        private async Task PreencherColunasDaListView()
        {
            listaMarca.Items.Clear();

            const string urlApiLocal = "https://localhost:7063/api/marca/total";

            using HttpClient client = new HttpClient();

            try
            {
                var opcoes = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string jsonResponse = await client.GetStringAsync(urlApiLocal);

                List<MarcaDTO>? marcas =
                    JsonSerializer.Deserialize<List<MarcaDTO>>(
                        jsonResponse,
                        opcoes);

                if (marcas is null)
                {
                    return;
                }

                foreach (MarcaDTO marca in marcas)
                {
                    AdicionarMarcaAoListView(marca);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao preencher a lista de marcas: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void AdicionarMarcaAoListView(MarcaDTO marca)
        {
            ListViewItem item = new ListViewItem(
            [
                marca.Id?.ToString() ?? string.Empty,
                marca.NomeMarca
            ]);

            item.Tag = marca.Id;
            listaMarca.Items.Add(item);
        }
        private void Voltar_Click(object sender, EventArgs e)
        {
            SubCarro pagina = new SubCarro();
            pagina.Show();
            this.Hide();
        }

        private void recarrega_Click(object sender, EventArgs e)
        {
            GetMarca pagina = new GetMarca();
            pagina.Show();
            this.Hide();
        }
    }
}
