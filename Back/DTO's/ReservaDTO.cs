using Back.Models;

namespace Back.DTO_s
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public int CarroId { get; set; }
        public int ClienteId { get; set; }
        public string? ClienteNome { get; set; } = string.Empty;

        public string? ModeloNome { get; set; } = string.Empty; 

        public Carro? carro { get; set; } = new Carro();
        public Cliente? cliente { get; set; } = new Cliente();

        //public DateOnly? dataDeReserva { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
