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
            listaCarro.Columns.Add("ID Marca", 80);
            listaCarro.Columns.Add("ID Modelo", 80);
            listaCarro.Columns.Add("Cor", 100);
            listaCarro.Columns.Add("Ano", 100);
            listaCarro.Columns.Add("Preço", 200);

            await PreencherColunasDaListView();
            
            

        }
        private async Task PreencherColunasDaListView()
        {
            listaCarro.Items.Clear();

            string urlApiLocal = "https://localhost:7063/api/carro";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonResponse = await client.GetStringAsync(urlApiLocal);
                    var opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };


                    List<CarroDTO> listaUsuarios = JsonSerializer.Deserialize<List<CarroDTO>>(jsonResponse, opcoes);

                    foreach (var usuario in listaUsuarios)
                    {

                        ListViewItem linha = new ListViewItem(usuario.id.ToString());

                        linha.SubItems.Add(usuario.MarcaId.ToString());
                        linha.SubItems.Add(usuario.ModeloId.ToString());
                        linha.SubItems.Add(usuario.Cor);
                        linha.SubItems.Add(usuario.Ano.ToString());
                        linha.SubItems.Add(usuario.Preco.ToString());

                        listaCarro.Items.Add(linha);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao preencher colunas: {ex.Message}");
                }
            }
        }
        private async void AdicionarCarroAoListView(CarroDTO carro)
        {
            ListViewItem item = new ListViewItem(new[]
            {
                carro.id?.ToString() ?? string.Empty,
                carro.MarcaId.ToString(),
                carro.ModeloId.ToString(),
                carro.Cor ?? string.Empty,
                carro.Ano?.ToString() ?? string.Empty,
                carro.Preco?.ToString() ?? string.Empty
            });

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
