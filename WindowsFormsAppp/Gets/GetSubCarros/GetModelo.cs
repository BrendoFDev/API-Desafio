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
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Puts.PutSubCarros.PutModelo pagina = new WindowsFormsAppp.Puts.PutSubCarros.PutModelo();
            pagina.Show();
        }



        private void Deletar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Deletes.DeleteSubCarros.DeleteModelo pagina = new WindowsFormsAppp.Deletes.DeleteSubCarros.DeleteModelo();
            pagina.Show();
        }

        private async void GetModelo_Load(object sender, EventArgs e)
        {
            listaModelo.View = View.Details;
            listaModelo.FullRowSelect = true;
            listaModelo.GridLines = true;

            listaModelo.Columns.Add("ID Marca", 80);
            listaModelo.Columns.Add("ID Modelo", 80);
            listaModelo.Columns.Add("Nome", 200);

            await PreencherColunasDaListView();
        }
        private async Task PreencherColunasDaListView()
        {
            listaModelo.Items.Clear();

            const string urlApiLocal = "https://localhost:7063/api/modelo/total";

            using HttpClient client = new HttpClient();

            try
            {
                var opcoes = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string jsonResponse = await client.GetStringAsync(urlApiLocal);

                List<ModeloDTO>? modelos =
                    JsonSerializer.Deserialize<List<ModeloDTO>>(
                        jsonResponse,
                        opcoes);

                if (modelos is null)
                {
                    return;
                }

                foreach (ModeloDTO modelo in modelos)
                {
                    AdicionarModeloAoListView(modelo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao preencher a lista de modelos: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void AdicionarModeloAoListView(ModeloDTO modelo)
        {
            ListViewItem item = new ListViewItem(
            [
                modelo.id?.ToString() ?? string.Empty,
                modelo.NomeModelo
            ]);

            item.Tag = modelo.id;
            listaModelo.Items.Add(item);
        }
        private void Voltar_Click(object sender, EventArgs e)
        {
            SubCarro pagina = new SubCarro();
            pagina.Show();
            this.Hide();
        }

        private void recarrega_Click(object sender, EventArgs e)
        {
            GetModelo pagina = new GetModelo();
            pagina.Show();
            this.Hide();
        }
    }
}
