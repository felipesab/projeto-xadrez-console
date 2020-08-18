using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
  public class Rainha : Peca
  {
    public Rainha(Cor cor, Tabuleiro tab) : base(cor, tab)
    {

    }

    public override string ToString()
    {
      return "Q";
    }

    public override bool PodeMover(Posicao pos)
    {
      return Tab.Peca(pos) == null || Tab.Peca(pos).Cor != Cor;
    }

    public override bool[,] MovimentosPossiveis()
    {
      bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
      Posicao pos = new Posicao(0, 0);

      //diagonal direta cima
      pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
        if (Tab.Peca(pos) != null)
          break;
        pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
      }

      //diagonal direita baixo
      pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
        if (Tab.Peca(pos) != null)
          break;
        pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
      }

      //diagonal esquerda baixo
      pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;
        if (Tab.Peca(pos) != null)
          break;
        pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
      }

      //diagonal esquerda baixo
      pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;

        if (Tab.Peca(pos) != null)
          break;

        pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
      }

      //cima
      pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
      while (Tab.PosicaoValida(pos) && PodeMover(pos))
      {
        mat[pos.Linha, pos.Coluna] = true;

        if (Tab.Peca(pos) != null)
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
