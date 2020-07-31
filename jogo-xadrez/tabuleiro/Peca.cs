﻿using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace tabuleiro
{
  public class Peca
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
  }
}
