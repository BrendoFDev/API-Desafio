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

namespace WindowsFormsAppp.Puts
{
    public partial class PutCliente : Form
    {
        public PutCliente()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || !int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Por favor, digite um ID numérico válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string nome = string.IsNullOrWhiteSpace(txtNome.Text) ? null : txtNome.Text;

            string cpf = string.IsNullOrWhiteSpace(txtCpf.Text) ? null : txtCpf.Text;

            


            var dadosCliente = new
            {
                id = id,
                nome = nome,
                cpf = cpf
            };

            string json = JsonSerializer.Serialize(dadosCliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                button1.Enabled = false;
                string url = $"https://localhost:7063/api/cliente/{id}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Campos preenchidos foram atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Erro na API: {response.StatusCode}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro de conexão: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button1.Enabled = true;
            }
        }
    }
}