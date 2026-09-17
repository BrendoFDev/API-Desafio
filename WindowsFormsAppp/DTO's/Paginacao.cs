using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Back.DTO_s;
using WindowsFormsAppp.Models;
namespace WindowsFormsAppp.DTO_s
{
    internal class Paginacao<T>
    {
        public IEnumerable<T> Items { get; set; } = [];

        public int TotalRegistro { get; set; }

        public int PaginaAtual { get; set; } = 1;

        public int TamanhoPagina { get; set; } = 10;

        public int TotalPagina => (int)Math.Ceiling((decimal)TotalRegistro / (decimal)TamanhoPagina);

        public bool ProximaPagina => PaginaAtual < TotalPagina;
    }
    internal class Paginacao<T, TMetadata> : Paginacao<T>
    {
        public TMetadata? Metadata { get; set; }
    }
}
