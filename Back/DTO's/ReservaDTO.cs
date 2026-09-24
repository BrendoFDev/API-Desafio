using Back.Models;

namespace Back.DTO_s
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public int CarroId { get; set; }
        public int ClienteId { get; set; }

        public string? Nome { get; set; }

        public string? NomeMarca { get; set; }


        //public DateOnly? dataDeReserva { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}