using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
  public class Peao : Peca
  {

    public Peao(Cor cor, Tabuleiro tab) : base(cor, tab)
    {

    }

    public override string ToString()
    {
      return "P";
    }

    public override bool PodeMover(Posicao pos)
    {
      return Tab.Peca(pos) == null;
    }

    public bool PodeComer(Posicao pos)
    {
      return Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor;
    }

    public override bool[,] MovimentosPossiveis()
    {
      bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
      Posicao pos = new Posicao(0, 0);

      if (Cor == Cor.Branco)
      {
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
        if (Tab.PosicaoValida(pos) && PodeComer(pos))
        {
          mat[pos.Linha, pos.Coluna] = true;
        }

        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
        if (Tab.PosicaoValida(pos) && PodeComer(pos))
        {
          mat[pos.Linha, pos.Coluna] = true;
        }

        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
          mat[pos.Linha, pos.Coluna] = true;
        }

        pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
        if (Tab.PosicaoValida(pos) && PodeMover(pos) && QtdMovimentos == 0)
        {
          mat[pos.Linha, pos.Coluna] = true;
        }
      }
      else
      {
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
        if (Tab.PosicaoValida(pos) && PodeComer(pos))
        {
          mat[pos.Linha, pos.Coluna] = true;
        }

        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
        if (Tab.PosicaoValida(pos) && PodeComer(pos))
        {
          mat[pos.Linha, pos.Coluna] = true;
        }

        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
          mat[pos.Linha, pos.Coluna] = true;
        }

        pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
        if (Tab.PosicaoValida(pos) && PodeMover(pos) && QtdMovimentos == 0)
        {
          mat[pos.Linha, pos.Coluna] = true;
        }
      }


      return mat;
    }
  }
}
