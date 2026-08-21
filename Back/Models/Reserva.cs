using System.Text.Json.Serialization;

namespace Back.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        public long CarroId { get; set; }
        [JsonIgnore]
        public Carro carro { get; set; } = default!;

        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente cliente { get; set; } = default!;

        public DateOnly dataDeReserva { get; set; } = DateOnly.FromDateTime(DateTime.Now);



    }
}
