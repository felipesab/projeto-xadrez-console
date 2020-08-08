using tabuleiro;
using System;
using xadrez;
using jogo_xadrez.xadrez;

namespace jogo_xadrez
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        PartidaXadrez match = new PartidaXadrez();

        while (!match.Terminada)
        {
          Console.Clear();
          Tela.ImprimirTabuleiro(match.Tab);

          Console.Write("Origem: ");
          Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

          Console.Clear();
          bool[,] mat = match.Tab.Peca(origem).MovimentosPossiveis();
          Tela.ImprimirTabuleiro(match.Tab, mat);
          Console.Write("Destino: ");
          Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

          match.ExecutaMovimento(origem, destino);
        }
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

      Console.ReadLine();
    }
  }
}
