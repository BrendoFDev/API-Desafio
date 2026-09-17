namespace Back.DTO_s
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public int CarroId { get; set; }
        public int ClienteId { get; set; }

        //public DateOnly? dataDeReserva { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
