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

        private void GetCarro_Load(object sender, EventArgs e)
        {
            
            listaCarro.View = View.Details;
            listaCarro.FullRowSelect = true; 
  
            listaCarro.Columns.Add("ID Carro", 80);
            listaCarro.Columns.Add("ID Marca", 80);
            listaCarro.Columns.Add("ID Modelo", 80); 
            listaCarro.Columns.Add("Cor", 100);        
            listaCarro.Columns.Add("Ano", 100);
            listaCarro.Columns.Add("Preço", 200);
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

                    // Converte o JSON para a lista de objetos
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
    }
}
