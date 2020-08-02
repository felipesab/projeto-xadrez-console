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
        Tabuleiro tab = new Tabuleiro(8, 8);

        tab.ColocarPeca(new Rei(Cor.Preto, tab), new Posicao(0, 0));
        tab.ColocarPeca(new Torre(Cor.Branco, tab), new Posicao(7, 7));

        Tela.ImprimirTabuleiro(tab);
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

      Console.ReadLine();
    }
  }
}
