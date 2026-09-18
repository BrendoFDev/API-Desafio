using System.Net.Http.Json;
using Back.Controllers;

namespace WindowsFormsAppp.Posts.SubCarros
{
    public partial class PostCliente : Form
    {

        public string teste { get; set; } = "criado";
        public PostCliente()
        {
            InitializeComponent();
        }
        private static readonly HttpClient client = new HttpClient();


        private void PostCliente_Load(object sender, EventArgs e)
        {

            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var cliente = new
            {
                nome=nome.Text,
                Cpf=cpf.Text
            };

            string url = "https://localhost:7063/api/cliente";

            try
            {

                HttpResponseMessage response = await client.PostAsJsonAsync(url, cliente);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nome.Clear();
                    cpf.Clear();
                    this.DialogResult = DialogResult.OK;
                    
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
