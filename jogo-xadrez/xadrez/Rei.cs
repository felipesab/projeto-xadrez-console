using tabuleiro;
using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez
{
  public class Rei : Peca
  {
    public Rei(Cor cor, Tabuleiro tab) : base(cor, tab)
    {

    }

    public override string ToString()
    {
      return "R";
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
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //diagonal cima-dir
      pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //direita
      pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //diagonal baixo-direita
      pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //baixo
      pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //diagonal baixo-esq
      pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //esquerda
      pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      //diagonal cima-esq
      pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
      if (Tab.PosicaoValida(pos) && PodeMover(pos))
        mat[pos.Linha, pos.Coluna] = true;

      return mat;
    }
  }
}
