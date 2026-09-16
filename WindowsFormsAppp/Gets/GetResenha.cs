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

        private void GetResenha_Load(object sender, EventArgs e)
        {
            listaReserva.View = View.Details;
            listaReserva.FullRowSelect = true;

            listaReserva.Columns.Add("ID da Reserva", 80);
            listaReserva.Columns.Add("ID do Cliente", 80);
            listaReserva.Columns.Add("ID do Carro", 200);
        }
        private async Task PreencherColunasDaListView()
        {
            listaReserva.Items.Clear();

            string urlApiLocal = "https://localhost:7063/api/reserva";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonResponse = await client.GetStringAsync(urlApiLocal);
                    var opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    // Converte o JSON para a lista de objetos
                    List<Reserva> listaUsuarios = JsonSerializer.Deserialize<List<Reserva>>(jsonResponse, opcoes);

                    foreach (var usuario in listaUsuarios)
                    {

                        ListViewItem linha = new ListViewItem(usuario.Id.ToString());
                        linha.SubItems.Add(usuario.ClienteId.ToString());
                        linha.SubItems.Add(usuario.CarroId.ToString());
                        listaReserva.Items.Add(linha);
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

