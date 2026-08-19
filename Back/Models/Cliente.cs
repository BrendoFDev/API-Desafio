namespace Back.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public DateOnly dataDeCriacao { get; set; }

        public Cliente(int id, string nome, string cpf)
        {
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
            dataDeCriacao = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
