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

namespace WindowsFormsAppp.Puts.PutSubCarros
{
    public partial class PutModelo : Form
    {
        public PutModelo()
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


            var dadosModelo = new
            {
                id = id,
                nomeModelo = nome
            };

            string json = JsonSerializer.Serialize(dadosModelo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                button1.Enabled = false;
                string url = $"https://localhost:7063/api/modelo/{id}";

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