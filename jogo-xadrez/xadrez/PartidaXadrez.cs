using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
using xadrez;

namespace jogo_xadrez.xadrez
{
  class PartidaXadrez
  {
    public Tabuleiro Tab { get; private set; }
    private int turno;
    private Cor jogadorAtual;
    public Boolean Terminada { get; private set; }
    public PartidaXadrez()
    {
      Tab = new Tabuleiro(8, 8);
      turno = 1;
      jogadorAtual = Cor.Branco;
      ColocarPecas();
      Terminada = false;
    }

    public void ExecutaMovimento(Posicao origem, Posicao destino)
    {
      Peca p = Tab.RetirarPeca(origem);
      Peca capturada = Tab.RetirarPeca(destino);
      Tab.ColocarPeca(p, destino);
      p.IncrementarMovimento();
    }

    public void ColocarPecas()
    {
      Tab.ColocarPeca(new Rei(Cor.Branco, Tab), new PosicaoXadrez('d', 1).ToPosicao());
      Tab.ColocarPeca(new Torre(Cor.Branco, Tab), new PosicaoXadrez('c', 1).ToPosicao());
      Tab.ColocarPeca(new Torre(Cor.Branco, Tab), new PosicaoXadrez('c', 2).ToPosicao());
      Tab.ColocarPeca(new Torre(Cor.Branco, Tab), new PosicaoXadrez('d', 2).ToPosicao());
      Tab.ColocarPeca(new Torre(Cor.Branco, Tab), new PosicaoXadrez('e', 2).ToPosicao());
      Tab.ColocarPeca(new Torre(Cor.Branco, Tab), new PosicaoXadrez('e', 1).ToPosicao());

      Tab.ColocarPeca(new Rei(Cor.Preto, Tab), new PosicaoXadrez('d', 8).ToPosicao());
      Tab.ColocarPeca(new Torre(Cor.Preto, Tab), new PosicaoXadrez('c', 8).ToPosicao());
      Tab.ColocarPeca(new Torre(Cor.Preto, Tab), new PosicaoXadrez('c', 7).ToPosicao());
      Tab.ColocarPeca(new Torre(Cor.Preto, Tab), new PosicaoXadrez('d', 7).ToPosicao());
      Tab.ColocarPeca(new Torre(Cor.Preto, Tab), new PosicaoXadrez('e', 7).ToPosicao());
      Tab.ColocarPeca(new Torre(Cor.Preto, Tab), new PosicaoXadrez('e', 8).ToPosicao());
    }
  }
}
