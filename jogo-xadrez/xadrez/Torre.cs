using tabuleiro;
using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez
{
  public class Torre : Peca
  {
    public Torre(Cor cor, Tabuleiro tab) : base(cor, tab)
    {

    }

    public override string ToString()
    {
      return "T";
    }

    public override bool PodeMover(Posicao pos)
    {
      return Tab.Peca(pos) == null || Tab.Peca(pos).Cor != Cor;
    }

    public override bool[,] MovimentosPossiveis()
    {
      bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

      Posicao pos = new Posicao(0, 0);

      //cima
      pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
      while(Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;

        if(Tab.Peca(pos) != null)
          break;

        pos.DefinirValores(pos.Linha - 1, pos.Coluna);
      }

      //direita
      pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;

        if (Tab.Peca(pos) != null)
          break;

        pos.DefinirValores(pos.Linha, pos.Coluna + 1);
      }

      //baixo
      pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;

        if (Tab.Peca(pos) != null)
          break;

        pos.DefinirValores(pos.Linha + 1, pos.Coluna);
      }

      //esquerda
      pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;

        if (Tab.Peca(pos) != null)
          break;

        pos.DefinirValores(pos.Linha, pos.Coluna - 1);
      }
      return mat;
    }
  }
}
