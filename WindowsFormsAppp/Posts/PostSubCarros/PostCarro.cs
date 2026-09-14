using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Back.Models;
using static System.Windows.Forms.DataFormats;
using System.Text.Json;

namespace WindowsFormsAppp.Posts.PostSubCarros
{
    public partial class PostCarro : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public PostCarro()
        {
            InitializeComponent();
        }

        
        private async void PostCarro_Load(object sender, EventArgs e)
        {
            await CarregarDados();
        }

      
        private async Task CarregarDados()
        {
            var apiGet = "https://localhost:7063/api/modelo/";

            try
            {
        
                var modelos = await client.GetFromJsonAsync<List<Modelo>>(apiGet);

                if (modelos != null)
                {
                    
                    modelo.DataSource = modelos;
                    modelo.DisplayMember = "NomeModelo"; 
                    modelo.ValueMember = "Id";     
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar modelos de carros: {ex.Message}", "Erro de Carregamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
           
            if (modelo.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecione um modelo de carro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idModeloSelecionado = Convert.ToInt32(modelo.SelectedValue);

            var user = new
            {
                preco = preco.Text,
                cor = Cor.Text,
                Ano = Ano.Text,
                ModeloId = idModeloSelecionado 
            };

            string url = "https://localhost:7063/carro";

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(url, user);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Carro cadastrado realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    preco.Clear();
                    Cor.Clear();
                    Ano.Clear();
                    modelo.SelectedIndex = -1; 
                }
                else
                {
                    string erroDetalhado = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Erro ao cadastrar: {response.StatusCode}\nDetalhes: {erroDetalhado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na comunicação com a API: {ex.Message}", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

  
}
