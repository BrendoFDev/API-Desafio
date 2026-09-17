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
using Back.DTO_s;
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
        private async void GetCliente_Load(object sender, EventArgs e)
        {
            listaCliente.View = View.Details;
            listaCliente.FullRowSelect = true;
            listaCliente.GridLines = true;

            listaCliente.Columns.Add("ID Cliente", 80);
            listaCliente.Columns.Add("Nome", 200);
            listaCliente.Columns.Add("CPF", 100);
            await PreencherColunasDaListView();
        }
        private async Task PreencherColunasDaListView()
        {
            listaCliente.Items.Clear();

            const string urlApiLocal = "https://localhost:7063/api/cliente/total";

            using HttpClient client = new HttpClient();

            try
            {
                var opcoes = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string jsonResponse = await client.GetStringAsync(urlApiLocal);

                List<ClienteDTO>? clientes =
                    JsonSerializer.Deserialize<List<ClienteDTO>>(
                        jsonResponse,
                        opcoes);

                if (clientes is null)
                {
                    return;
                }

                foreach (ClienteDTO cliente in clientes)
                {
                    AdicionarClienteAoListView(cliente);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao preencher a lista de modelos: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void AdicionarClienteAoListView(ClienteDTO cliente)
        {
            ListViewItem item = new ListViewItem(
            [
                cliente.id?.ToString() ?? string.Empty,
                cliente.Nome,
                cliente.Cpf
            ]);

            item.Tag = cliente.id;
            listaCliente.Items.Add(item);
        }

        private void Voltar_Click(object sender, EventArgs e)
        {
            Index pagina = new Index();
            pagina.Show();
            this.Hide();
        }

        private void recarrega_Click(object sender, EventArgs e)
        {
            GetCliente pagina = new GetCliente();
            pagina.Show();
            this.Hide();
        }
    }
}
