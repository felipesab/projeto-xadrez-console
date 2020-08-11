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
    public int Turno { get; private set; }
    public Cor JogadorAtual { get; private set; }
    public Boolean Terminada { get; private set; }
    public PartidaXadrez()
    {
      Tab = new Tabuleiro(8, 8);
      Turno = 1;
      JogadorAtual = Cor.Branco;
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

    public void RealizaJogada(Posicao origem, Posicao destino)
    {
      ExecutaMovimento(origem, destino);
      Turno++;
      MudarJogador();
    }

    private void MudarJogador()
    {
      if (JogadorAtual == Cor.Preto)
        JogadorAtual = Cor.Branco;
      else
        JogadorAtual = Cor.Preto;
    }

    public void ValidarOrigem(Posicao pos)
    {
      if (Tab.Peca(pos) == null)
      {
        throw new TabuleiroException("Não existe peça nessa posição!");
      }

      if (Tab.Peca(pos).Cor != JogadorAtual)
      {
        throw new TabuleiroException("Está peça pertence ao outro jogador, escolha uma de suas peças para realizar uma jogada!");
      }

      if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
      {
        throw new TabuleiroException("Não existe movimentos possíveis para essa peça!");
      }
    }

    public void ValidarDestino(Posicao origem, Posicao destino)
    {
      if (!Tab.Peca(origem).PodeMoverPara(destino))
      {
        throw new TabuleiroException("Posição de destino inválida para esta peça!");
      }
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
