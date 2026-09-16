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
using Back.Models;
using static System.Windows.Forms.DataFormats;
using System.Text.Json;
using Back.DTO_s;
//using WindowsFormsAppp.Models;

namespace WindowsFormsAppp.Posts.SubCarros
{
    public partial class PostModelo : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public PostModelo()
        {
            InitializeComponent();
        }


        private async void PostModelo_Load(object sender, EventArgs e)
        {
            await CarregarMarcas();
        }


        private async Task CarregarMarcas()
        {
            var apiGetMarcas = "https://localhost:7063/api/marca/";

            try
            {
                var marcas = await client.GetFromJsonAsync<Paginacao<Marca>>(apiGetMarcas);

                if (marcas != null)
                {
                    

                    comboMarca.DataSource = marcas.Items;
                    comboMarca.DisplayMember = "NomeMarca";
                    comboMarca.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar marcas: {ex.Message}", "Erro de Carregamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            if (comboMarca.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecione uma marca.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idMarcaSelecionada = Convert.ToInt32(comboMarca.SelectedValue);

            var novoModelo = new
            {
                NomeModelo = ModeloNome.Text,
                MarcaId = idMarcaSelecionada
            };

            string url = "https://localhost:7063/api/modelo";

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(url, novoModelo);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Modelo cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ModeloNome.Clear();
                    comboMarca.SelectedIndex = -1;
                }
                else
                {
                    string erroDetalhado = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Erro ao cadastrar modelo: {response.StatusCode}\nDetalhes: {erroDetalhado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na comunicação com a API: {ex.Message}", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
