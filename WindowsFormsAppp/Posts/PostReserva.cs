using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using System.Text.Json;
using Back.Models;
using System.Net.Http.Json;

namespace WindowsFormsAppp.Posts
{
    public partial class PostReserva : Form
    {
        public PostReserva()
        {
            InitializeComponent();
        }

        private static readonly HttpClient client = new HttpClient();

        private async void button1_Click(object sender, EventArgs e)
        {
            var reservas = new
            {
                CarroId = crId.Text,
                ClienteId = cId.Text,
            };

            string url = "https:/localhost:7063/api/cliente";

            try
            {

                HttpResponseMessage response = await client.PostAsJsonAsync(url, reservas);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cId.Clear();
                    crId.Clear();

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
