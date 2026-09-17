using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WindowsFormsAppp.Models
{
    internal class Reserva
    {

        public int Id { get; set; }

        public int CarroId { get; set; }
        [JsonIgnore]
        [ForeignKey("CarroId")]
        public Carro carro { get; set; } = default!;

        public int ClienteId { get; set; }
        [JsonIgnore]
        [ForeignKey("ClienteId")]
        public Cliente cliente { get; set; } = default!;

        public DateOnly dataDeReserva { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    }
}
