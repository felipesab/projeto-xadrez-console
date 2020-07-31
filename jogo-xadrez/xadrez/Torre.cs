using tabuleiro;
using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez
{
  public class Torre : Peca
  {
    public Torre(Cor cor, Tabuleiro tab) : base(cor, tab)
    {

    }

    public override string ToString()
    {
      return "T";
    }
  }
}
