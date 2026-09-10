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

namespace WindowsFormsAppp
{
    public partial class Cadastro : Form
    {

        


        public Cadastro()
        {
            InitializeComponent();
        }

        private static readonly HttpClient client = new HttpClient();

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
           
            var user = new
            {
                username = userCAD.Text,
                email = emailCAD.Text,
                senha = senhaCAD.Text
            };

          
            string url = "https://localhost:7063/api/user";

            try
            {
               
                HttpResponseMessage response = await client.PostAsJsonAsync(url, user);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    emailCAD.Clear();
                    senhaCAD.Clear();
                    userCAD.Clear();
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


        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login novaPagina = new Login();


            novaPagina.Show();
            this.Hide();

        }
    }
}

