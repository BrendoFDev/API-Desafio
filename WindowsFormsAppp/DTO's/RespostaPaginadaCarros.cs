using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back.DTO_s;

namespace WindowsFormsAppp.DTO_s
{
    internal sealed class RespostaPaginadaCarros
    {
        public int PaginaAtual { get; set; }

        public int TamanhoPagina { get; set; }

        public int TotalRegistros { get; set; }

        public int TotalPaginas { get; set; }

        public List<CarroDTO> Items { get; set; } = [];
    }
}
