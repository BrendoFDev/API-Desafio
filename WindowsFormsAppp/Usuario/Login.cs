using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json;
using static System.Windows.Forms.DataFormats;
using WindowsFormsAppp.Usuario;
using System.Text.Json;
using WindowsFormsAppp.Gets;

namespace WindowsFormsAppp.Usuario
{
    public partial class Login : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cadastro novaPagina = new Cadastro();


            novaPagina.Show();
            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(emailLOG.Text) || string.IsNullOrWhiteSpace(senhaLOG.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var loginDados = new
            {
                email = emailLOG.Text,
                senha = senhaLOG.Text
            };

            
            string url = "https://localhost:7063/api/auth/login";

            try
            {
               
                HttpResponseMessage response = await client.PostAsJsonAsync(url, loginDados);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Login realizado com sucesso!", "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    string resultadoJson = await response.Content.ReadAsStringAsync();

                    
                    WindowsFormsAppp.Gets.Index formPrincipal = new WindowsFormsAppp.Gets.Index();
                    formPrincipal.Show();
                    this.Hide();

                }
                else
                {
                   
                    string erroDetalhado = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Falha no login: {erroDetalhado}", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na comunicação com a API: {ex.Message}", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
