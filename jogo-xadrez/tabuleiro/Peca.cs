using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace tabuleiro
{
  public abstract class Peca
  {
    public Posicao Posicao { get; set; }
    public Cor Cor { get; protected set; }
    public int QtdMovimentos { get; protected set; }
    public Tabuleiro Tab { get; set; }

    public Peca()
    {

    }

    public Peca(Cor cor, Tabuleiro tab)
    {
      Posicao = null;
      Cor = cor;
      Tab = tab;
      QtdMovimentos = 0;
    }

    public void IncrementarMovimento()
    {
      QtdMovimentos++;
    }

    public void DecrementarMovimento()
    {
      QtdMovimentos--;
    }

    public bool ExisteMovimentosPossiveis()
    {
      bool[,] mat = MovimentosPossiveis();

      for(int i = 0; i<Tab.Linhas; i++)
      {
        for(int j = 0; j<Tab.Colunas; j++)
        {
          if (mat[i, j] == true)
          {
            return true;
          } 
        }
      }

      return false;
    }

    public bool MovimentoPossivel(Posicao destino)
    {
      return MovimentosPossiveis()[destino.Linha, destino.Coluna];
    }

    public abstract bool[,] MovimentosPossiveis();
    public abstract bool PodeMover(Posicao pos);
  }
}
