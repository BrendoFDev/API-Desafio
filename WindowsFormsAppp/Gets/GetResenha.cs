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
    public partial class GetResenha : Form
    {
        public GetResenha()
        {
            InitializeComponent();
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Puts.PutReserva pagina = new WindowsFormsAppp.Puts.PutReserva();
            pagina.Show();
        }

        private void Criar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Posts.PostReserva pagina = new WindowsFormsAppp.Posts.PostReserva();
            pagina.Show();
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            WindowsFormsAppp.Deletes.DeleteReserva pagina = new WindowsFormsAppp.Deletes.DeleteReserva();
            pagina.Show();
        }

        private async void GetResenha_Load(object sender, EventArgs e)
        {
            listaReserva.View = View.Details;
            listaReserva.FullRowSelect = true;
            listaReserva.GridLines = true;

            listaReserva.Columns.Add("ID da Reserva", 150);
            listaReserva.Columns.Add("ID do Cliente", 80);
            listaReserva.Columns.Add("Nome do Cliente", 180);
            listaReserva.Columns.Add("ID do Carro", 100);
            listaReserva.Columns.Add("Nome do Carro", 200);
            await PreencherColunasDaListView();
        }
        private async Task PreencherColunasDaListView()
        {
            listaReserva.Items.Clear();

            const string urlApiLocal = "https://localhost:7063/api/reservas/total";

            using HttpClient client = new HttpClient();

            try
            {
                var opcoes = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string jsonResponse = await client.GetStringAsync(urlApiLocal);

                List<ReservaDTO>? reservas =
                    JsonSerializer.Deserialize<List<ReservaDTO>>(
                        jsonResponse,
                        opcoes);

                if (reservas is null)
                {
                    return;
                }

                foreach (ReservaDTO reserva in reservas)
                {
                    AdicionarReservaAoListView(reserva);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao preencher a lista de reservas: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void AdicionarReservaAoListView(ReservaDTO reserva)
        {
            ListViewItem item = new ListViewItem(
            [
                reserva.Id.ToString(),
                reserva.ClienteId.ToString(),
                reserva.ClienteNome.ToString(),
                reserva.CarroId.ToString(),
                reserva.ModeloNome.ToString()

            ]);

            item.Tag = reserva.Id;
            listaReserva.Items.Add(item);
        }
        private void Voltar_Click(object sender, EventArgs e)
        {
            Index pagina = new Index();
            pagina.Show();
            this.Hide();
        }

        private void recarrega_Click(object sender, EventArgs e)
        {
            GetResenha pagina= new GetResenha();
            pagina.Show();
            this.Hide();
        }
    }
}

