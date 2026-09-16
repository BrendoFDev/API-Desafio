using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Back.DTO_s;
using Back.DTO_s.ModelosDTO;
using Back.Models;
//using WindowsFormsAppp.Models;

namespace WindowsFormsAppp.Posts.PostSubCarros
{
    public partial class PostCarro : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public PostCarro()
        {
            InitializeComponent();

           
            cmbMarca.SelectedIndexChanged += CmbMarca_SelectedIndexChanged;
        }

        private async void PostCarro_Load(object sender, EventArgs e)
        {
            await CarregarMarcas(); 
        }

        private async void CmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (cmbMarca.SelectedValue != null && int.TryParse(cmbMarca.SelectedValue.ToString(), out int idMarca))
            {
                await CarregarModelosPorMarca(idMarca);
            }
            else
            {
                cmbModelo.DataSource = null; 
            }
        }

        private async Task CarregarMarcas()
        {
            var apiGet = "https://localhost:7063/api/marca/";

            try
            {
                var listaMarcas = await client.GetFromJsonAsync<Paginacao<Marca>>(apiGet);

                if (listaMarcas != null)
                {
                   
                    cmbMarca.SelectedIndexChanged -= CmbMarca_SelectedIndexChanged;

                    cmbMarca.DataSource = listaMarcas.Items;
                    cmbMarca.DisplayMember = "NomeMarca";
                    cmbMarca.ValueMember = "Id";
                    cmbMarca.SelectedIndex = -1; 

                    cmbMarca.SelectedIndexChanged += CmbMarca_SelectedIndexChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar marcas de carros: {ex.Message}", "Erro de Carregamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task CarregarModelosPorMarca(int marcaId)
        {
            
            var apiGet = $"https://localhost:7063/api/modelo/pormarca/{marcaId}";

            try
            {
                var modelos = await client.GetFromJsonAsync<List<ResponseModeloDTO>>(apiGet);

                cmbModelo.DataSource = modelos;
                cmbModelo.DisplayMember = "Nome";
                cmbModelo.ValueMember = "Id";
                cmbModelo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar modelos desta marca: {ex.Message}", "Erro de Carregamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (cmbModelo.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecione um modelo de carro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMarca.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecione uma marca de carro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idModeloSelecionado = Convert.ToInt32(cmbModelo.SelectedValue);
            int idMarcaSelecionada = Convert.ToInt32(cmbMarca.SelectedValue);

            var user = new
            {
                preco = preco.Text,
                cor = Cor.Text,
                Ano = Ano.Text,
                ModeloId = idModeloSelecionado,
                MarcaId = idMarcaSelecionada
            };

            string url = "https://localhost:7063/api/carro";

            try
            {
                button1.Enabled = false;
                HttpResponseMessage response = await client.PostAsJsonAsync(url, user);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Carro cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    preco.Clear();
                    Cor.Clear();
                    Ano.Clear();
                    cmbModelo.DataSource = null;
                    cmbMarca.SelectedIndex = -1;
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
            finally
            {
                button1.Enabled = true;
            }
        }
    }
}
