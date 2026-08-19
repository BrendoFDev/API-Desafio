namespace Back.Models
{
    public class Carro
    {
        public long Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public float Preco { get; set; }

        public Carro(long id, string modelo, string marca, int ano, string cor, float preco)
        {
            Id = id;
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
            Cor = cor;
            Preco = preco;

        }

    }
}
