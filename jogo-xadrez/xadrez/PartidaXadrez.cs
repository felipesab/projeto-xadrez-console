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
    public bool Xeque { get; set; }
    private HashSet<Peca> pecas;
    private HashSet<Peca> pecasCapturadas;

    public PartidaXadrez()
    {
      Tab = new Tabuleiro(8, 8);
      Turno = 1;
      JogadorAtual = Cor.Branco;
      Xeque = false;
      pecas = new HashSet<Peca>();
      pecasCapturadas = new HashSet<Peca>();
      ColocarPecas();
      Terminada = false;
    }

    public Peca ExecutaMovimento(Posicao origem, Posicao destino)
    {
      Peca p = Tab.RetirarPeca(origem);
      Peca capturada = Tab.RetirarPeca(destino);
      Tab.ColocarPeca(p, destino);
      p.IncrementarMovimento();

      if (capturada != null)
        pecasCapturadas.Add(capturada);

      return capturada;
    }

    public HashSet<Peca> PecasCapturadas(Cor cor)
    {
      HashSet<Peca> aux = new HashSet<Peca>();

      foreach (Peca x in pecasCapturadas)
      {
        if (x.Cor == cor)
        {
          aux.Add(x);
        }
      }

      return aux;
    }

    public HashSet<Peca> PecasEmJogo(Cor cor)
    {
      HashSet<Peca> aux = new HashSet<Peca>();

      foreach (Peca x in pecas)
      {
        if (x.Cor == cor)
        {
          aux.Add(x);
        }
      }

      aux.ExceptWith(PecasCapturadas(cor));
      return aux;
    }

    public void RealizaJogada(Posicao origem, Posicao destino)
    {
      Peca capturada = ExecutaMovimento(origem, destino);

      if (EstaEmXeque(JogadorAtual))
      {
        DesfazerMovimento(origem, destino, capturada);
        throw new TabuleiroException("Este movimento não pode ser realizado, pois deixará o seu rei em Xeque!");
      }

      if (EstaEmXeque(PecaAdversaria(JogadorAtual)))
        Xeque = true;
      else
        Xeque = false;

      Turno++;
      MudarJogador();
    }

    private void DesfazerMovimento(Posicao origem, Posicao destino, Peca capturada)
    {
      Peca p = Tab.RetirarPeca(destino);
      p.DecrementarMovimento();
      Tab.ColocarPeca(p, origem);

      if (capturada != null)
      {
        Tab.ColocarPeca(capturada, destino);
        pecasCapturadas.Remove(capturada);
      }
    }

    private void MudarJogador()
    {
      if (JogadorAtual == Cor.Preto)
        JogadorAtual = Cor.Branco;
      else
        JogadorAtual = Cor.Preto;
    }

    private Cor PecaAdversaria(Cor cor)
    {
      if (cor == Cor.Branco)
      {
        return Cor.Preto;
      }
      else
      {
        return Cor.Branco;
      }
    }

    private Peca Rei(Cor cor)
    {
      foreach (Peca x in PecasEmJogo(cor))
      {
        if (x is Rei)
          return x;
      }

      return null;
    }

    private bool EstaEmXeque(Cor cor)
    {
      Peca rei = Rei(cor);

      foreach (Peca x in PecasEmJogo(PecaAdversaria(cor)))
      {
        bool[,] mat = x.MovimentosPossiveis();
        if (mat[rei.Posicao.Linha, rei.Posicao.Coluna])
          return true;
      }

      return false;
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

    public void AdicionarPeca(char linha, int coluna, Peca peca)
    {
      Tab.ColocarPeca(peca, new PosicaoXadrez(linha, coluna).ToPosicao());
      pecas.Add(peca);
    }

    public void ColocarPecas()
    {
      AdicionarPeca('d', 1, new Rei(Cor.Branco, Tab));
      AdicionarPeca('c', 1, new Torre(Cor.Branco, Tab));
      AdicionarPeca('c', 2, new Torre(Cor.Branco, Tab));
      AdicionarPeca('d', 2, new Torre(Cor.Branco, Tab));
      AdicionarPeca('e', 1, new Torre(Cor.Branco, Tab));
      AdicionarPeca('e', 2, new Torre(Cor.Branco, Tab));

      AdicionarPeca('d', 8, new Rei(Cor.Preto, Tab));
      AdicionarPeca('c', 7, new Torre(Cor.Preto, Tab));
      AdicionarPeca('c', 8, new Torre(Cor.Preto, Tab));
      AdicionarPeca('d', 7, new Torre(Cor.Preto, Tab));
      AdicionarPeca('e', 8, new Torre(Cor.Preto, Tab));
      AdicionarPeca('e', 7, new Torre(Cor.Preto, Tab));
    }
  }
}
