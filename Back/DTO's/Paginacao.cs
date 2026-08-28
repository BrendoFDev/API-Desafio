namespace Back.DTO_s
{
    public class Paginacao<T>
    {
        public IEnumerable<T> Items { get; set; } = [];

        public int TotalRegistro { get; set; }

        public int PaginaAtual { get; set; } = 1;

        public int TamanhoPagina { get; set; } = 10;

        public int TotalPagina => (int)Math.Ceiling((decimal)TotalRegistro / (decimal)TamanhoPagina);

        public bool ProximaPagina => PaginaAtual < TotalPagina;

    }

    public class Paginacao<T,TMetadata>: Paginacao<T>
    {
        public TMetadata? Metadata { get; set; }
    }

}
