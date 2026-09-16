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
using Back.Models;
//using WindowsFormsAppp.Models;

namespace WindowsFormsAppp.Gets
{
    public partial class GetCliente : Form
    {
        public GetCliente()
        {
            InitializeComponent();
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Puts.PutCliente pagina = new WindowsFormsAppp.Puts.PutCliente();
            pagina.Show();
        }
        private void Criar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Posts.SubCarros.PostCliente pagina = new WindowsFormsAppp.Posts.SubCarros.PostCliente();
            pagina.Show();
        }
        private void Deletar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Deletes.DeleteCliente pagina = new WindowsFormsAppp.Deletes.DeleteCliente();
            pagina.Show();
        }
        private void GetCliente_Load(object sender, EventArgs e)
        {
            listaCliente.View = View.Details;
            listaCliente.FullRowSelect = true;

            listaCliente.Columns.Add("ID Marca", 80);
            listaCliente.Columns.Add("ID Modelo", 80);
            listaCliente.Columns.Add("Nome", 200);
        }
        private async Task PreencherColunasDaListView()
        {
            listaCliente.Items.Clear();

            string urlApiLocal = "https://localhost:7063/api/cliente";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonResponse = await client.GetStringAsync(urlApiLocal);
                    var opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    // Converte o JSON para a lista de objetos
                    List<Cliente> listaUsuarios = JsonSerializer.Deserialize<List<Cliente>>(jsonResponse, opcoes);

                    foreach (var usuario in listaUsuarios)
                    {

                        ListViewItem linha = new ListViewItem(usuario.id.ToString());
                        linha.SubItems.Add(usuario.Nome);
                        linha.SubItems.Add(usuario.Cpf);
                        listaCliente.Items.Add(linha);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao preencher colunas: {ex.Message}");
                }
            }
        }

        private void Voltar_Click(object sender, EventArgs e)
        {
            Index pagina = new Index();
            pagina.Show();
            this.Hide();
        }
    }
}
