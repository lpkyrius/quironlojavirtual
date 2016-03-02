using System;

// Auxilia a barra de navegação na paginação

namespace Quiron.LojaVirtual.Web.Models
{
    public class Paginacao
    {
        public int ItensTotal { get; set; }

        public int ItensPorPagina { get; set; }

        public int PaginaAtual { get; set; }

        public int TotalPaginas
        {

            get {return (int)Math.Ceiling((decimal)ItensTotal / ItensPorPagina);} // Ceiling para arredondar para cima o resultado da divisão
        }

    }
