using tabuleiro;
using System;
using xadrez;
using System.Collections.Generic;
using System.Text;
using jogo_xadrez.xadrez;
using System.Text.RegularExpressions;

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
          ImprimirPeca(tab.Peca(i, j));
        }

        Console.WriteLine();
      }

      Console.WriteLine("  A B C D E F G H");
    }

    public static void ImprimirPartida(PartidaXadrez match)
    {
      Console.Clear();
      ImprimirTabuleiro(match.Tab);
      ImprimirCapturadas(match);

      Console.WriteLine();
      Console.WriteLine($"Turno {match.Turno}");

      if (!match.Terminada)
      {
        Console.WriteLine($"Aguardando jogada - {match.JogadorAtual}");
        Console.WriteLine();
        if (match.Xeque)
          Console.WriteLine("XEQUE!");
      }
      else
      {
        Console.WriteLine("XEQUEMATE!");
        Console.WriteLine($"VENCEDOR: {match.JogadorAtual}");
      }

    }

    public static void ImprimirCapturadas(PartidaXadrez match)
    {
      Console.WriteLine();
      Console.WriteLine("Peças capturadas:");
      Console.Write("Brancas: [");
      ImprimirConjuntoPecas(match.PecasCapturadas(Cor.Branco));
      Console.WriteLine("]");

      Console.Write("Pretas: [");
      ImprimirConjuntoPecas(match.PecasCapturadas(Cor.Preto));
      Console.WriteLine("]");

    }

    public static void ImprimirConjuntoPecas(HashSet<Peca> pecas)
    {
      foreach (Peca x in pecas)
      {
        Console.Write(x + " ");
      }
    }

    public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] possicoesPossiveis)
    {
      for (int i = 0; i < tab.Linhas; i++)
      {
        Console.Write(8 - i);
        Console.Write(" ");

        for (int j = 0; j < tab.Colunas; j++)
        {
          ConsoleColor corOriginal = Console.BackgroundColor;
          ConsoleColor possicaoDestacada = ConsoleColor.DarkGray;

          if (possicoesPossiveis[i, j] == true)
            Console.BackgroundColor = possicaoDestacada;

          ImprimirPeca(tab.Peca(i, j));
          Console.BackgroundColor = corOriginal;
        }

        Console.WriteLine();
      }

      Console.WriteLine("  A B C D E F G H");
    }

    public static PosicaoXadrez LerPosicaoXadrez()
    {
      string posicao = Console.ReadLine();
      int linha = int.Parse("" + posicao[1]);
      char coluna = posicao[0];

      return new PosicaoXadrez(coluna, linha);
    }

    public static void ImprimirPeca(Peca peca)
    {
      if (peca == null)
      {
        Console.Write("- ");
      }
      else
      {
        if (peca.Cor == Cor.Branco)
        {
          Console.Write(peca);
        }
        else if (peca.Cor == Cor.Preto)
        {
          ConsoleColor aux = Console.ForegroundColor;
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write(peca);
          Console.ForegroundColor = aux;
        }

        Console.Write(" ");
      }
    }
  }
}
