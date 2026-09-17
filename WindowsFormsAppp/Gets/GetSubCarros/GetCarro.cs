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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WindowsFormsAppp.DTO_s;

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

        }

        private void Criar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Posts.PostSubCarros.PostCarro pagina = new WindowsFormsAppp.Posts.PostSubCarros.PostCarro();
            pagina.Show();

        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Deletes.DeleteSubCarros.Deletecarro pagina = new WindowsFormsAppp.Deletes.DeleteSubCarros.Deletecarro();
            pagina.Show();

        }

        private async void GetCarro_Load(object sender, EventArgs e)
        {
            listaCarro.View = View.Details;
            listaCarro.FullRowSelect = true;

            listaCarro.Columns.Add("ID Carro", 80);
            listaCarro.Columns.Add("Marca", 80);
            listaCarro.Columns.Add("Modelo", 80);
            listaCarro.Columns.Add("Cor", 100);
            listaCarro.Columns.Add("Ano", 100);
            listaCarro.Columns.Add("Preço", 200);

            await PreencherColunasDaListView();
           
            
            

        }
        private async Task PreencherColunasDaListView()
        {
            listaCarro.Items.Clear();

            const string urlApiLocal = "https://localhost:7063/api/carro/total";

            using HttpClient client = new HttpClient();

            try
            {
                var opcoes = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string jsonResponse = await client.GetStringAsync(urlApiLocal);

                List<CarroDTO>? carros =
                    JsonSerializer.Deserialize<List<CarroDTO>>(
                        jsonResponse,
                        opcoes);

                if (carros is null)
                {
                    return;
                }

                foreach (CarroDTO carro in carros)
                {
                    AdicionarCarroAoListView(carro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao preencher a lista de carros: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void AdicionarCarroAoListView(CarroDTO carro)
        {
            ListViewItem item = new ListViewItem(
            [
                carro.id?.ToString() ?? string.Empty,
                carro.NomeMarca,
                carro.NomeModelo,
                carro.Cor ?? string.Empty,
                carro.Ano?.ToString() ?? string.Empty,
                carro.Preco?.ToString() ?? string.Empty
            ]);

            item.Tag = carro.id;
            listaCarro.Items.Add(item);
        }

        private void Voltar_Click(object sender, EventArgs e)
        {
            SubCarro pagina = new SubCarro();
            pagina.Show();
            this.Hide();
        }
    }
}
