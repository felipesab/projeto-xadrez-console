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

      PartidaXadrez match = new PartidaXadrez();

      while (!match.Terminada)
      {
        try
        {
          Console.Clear();
          Tela.ImprimirTabuleiro(match.Tab);

          Console.WriteLine();
          Console.WriteLine($"Turno {match.Turno}");
          Console.WriteLine($"Aguardando jogada - {match.JogadorAtual}");
          Console.WriteLine();
          Console.Write("Origem: ");
          Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
          match.ValidarOrigem(origem);

          Console.Clear();
          bool[,] mat = match.Tab.Peca(origem).MovimentosPossiveis();
          Tela.ImprimirTabuleiro(match.Tab, mat);
          Console.WriteLine();
          Console.Write("Destino: ");
          Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
          match.ValidarDestino(origem, destino);

          match.RealizaJogada(origem, destino);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          Console.ReadLine();
        }
      }

      Console.ReadLine();
    }
  }
}
