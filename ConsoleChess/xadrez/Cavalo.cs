﻿using tabuleiro;

namespace xadrez
{
     class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }
        public override string ToString()
        {
            return "C";
        }
    }
}
