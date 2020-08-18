using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using tabuleiro;

namespace xadrez
{
  public class Cavalo : Peca
  {
    public Cavalo(Cor cor, Tabuleiro tab) : base(cor, tab)
    {

    }

    public override bool PodeMover(Posicao pos)
    {
      return Tab.Peca(pos) == null || Tab.Peca(pos).Cor != Cor;
    }

    public override string ToString()
    {
      return "C";
    }

    public override bool[,] MovimentosPossiveis()
    {
      bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
      Posicao pos = new Posicao(0, 0);

      //Para cima esquerda
      pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
      if(Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //Para cima direita
      pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //Para baixo esquerda
      pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //Para baixo direita
      pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //Para baixo direita
      pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //Para esquerda cima
      pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //Para esquerda baixo
      pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //Para direita cima
      pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //Para direita cima
      pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      return mat;

    }


  }
}
