using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppp.Deletes.DeleteSubCarros
{
    public partial class DeleteModelo : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public DeleteModelo()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || !int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Por favor, insira um ID numérico válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            var confirmacao = MessageBox.Show($"Tem certeza que deseja deletar o ID {id}?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacao == DialogResult.No) return;

            try
            {
                
                string urlApi = $"https://localhost:7063/api/modelo/{id}";

                
                HttpResponseMessage response = await client.DeleteAsync(urlApi);

                
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Registro deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtId.Clear(); 
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("O ID informado não foi encontrado no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Erro ao deletar: {response.ReasonPhrase}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro de comunicação com a API: {ex.Message}", "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
