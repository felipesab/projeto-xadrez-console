using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using tabuleiro;

namespace tabuleiro
{
  public class Tabuleiro
  {
    public int Linhas { get; set; }
    public int Colunas { get; set; }
    private Peca[,] Pecas { get; set; }

    public Tabuleiro()
    {

    }

    public Tabuleiro(int linhas, int colunas)
    {
      Linhas = linhas;
      Colunas = colunas;

      Pecas = new Peca[linhas, colunas];
    }

    public Peca Peca(int linha, int coluna)
    {
      return Pecas[linha, coluna];
    }

    public Peca Peca(Posicao pos)
    {
      return Pecas[pos.Linha, pos.Coluna];
    }

    public void ColocarPeca(Peca peca, Posicao pos)
    {
      if (ExistePeca(pos))
      {
        throw new TabuleiroException($"Já existe uma peça na posição ({pos})");
      }
      Pecas[pos.Linha, pos.Coluna] = peca;
      peca.Posicao = pos;
    }

    public Peca RetirarPeca(Posicao pos)
    {
      if (Peca(pos) == null)
        return null;

      Peca aux = Peca(pos);
      aux.Posicao = null;
      Pecas[pos.Linha, pos.Coluna] = null;

      return aux;
    }

    public bool PosicaoValida(Posicao pos)
    {
      if (pos.Linha >= this.Linhas  || pos.Coluna >= this.Colunas || pos.Linha < 0 || pos.Coluna < 0)
      {
        return false;
      }

      return true;
    }

    public void ValidarPosicao(Posicao pos)
    {
      if (!PosicaoValida(pos))
      {
        throw new TabuleiroException($"A posição ({pos}) é inválida.");
      }
    }

    public bool ExistePeca(Posicao pos)
    {
      ValidarPosicao(pos);

      return Pecas[pos.Linha, pos.Coluna] != null;
    }

  }
}
