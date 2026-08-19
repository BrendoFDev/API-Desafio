namespace Back.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public Carro carro{get; set;}
        public Cliente cliente{get; set;}

        public DateOnly dataDeReserva { get; set; }

        public Reserva(int id, Carro carro, Cliente cliente)
        {
            Id = id;
            this.carro = carro;
            this.cliente = cliente;
            dataDeReserva = DateOnly.FromDateTime(DateTime.Now);
        }


    }
}
