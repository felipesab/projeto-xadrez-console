using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace jogo_xadrez.tabuleiro
{
    public class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        public Peca[,] Pecas { get; set; }

        public Tabuleiro()
        {

        }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;

            Pecas = new Peca[linhas, colunas];
        }

    }
}
