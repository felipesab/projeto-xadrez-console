using tabuleiro;
using System;
using System.Collections.Generic;
using System.Text;

namespace jogo_xadrez
{
  class Tela
  {
    public static void ImprimirTabuleiro(Tabuleiro tab)
    {
      for (int i = 0; i < tab.Linhas; i++)
      {
        Console.Write(8 - i);
        Console.Write(" ");

        for (int j = 0; j < tab.Colunas; j++)
        {
          if (tab.Peca(i, j) == null)
          {
            Console.Write("- ");
          }
          else
          {
            ImprimirPeca(tab.Peca(i, j));
            Console.Write(" ");
          }
        }

        Console.WriteLine();
      }

      Console.WriteLine("  A B C D E F G H");
    }

    public static void ImprimirPeca(Peca peca)
    {
      if(peca.Cor == Cor.Branco)
      {
        Console.Write(peca);
      }
      else if(peca.Cor == Cor.Preto)
      {
        ConsoleColor aux = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(peca);
        Console.ForegroundColor = aux;
      }
    }
  }
}
