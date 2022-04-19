using tabuleiro;

namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }
        public override string ToString()
        {
            return "B";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = Tabuleiro.peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.NumeroLinhas, Tabuleiro.NumeroColunas];

            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
                {
                    break;
                }
            pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }


            pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            while(Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[Posicao.Linha, Posicao.Coluna] = true;
                if(Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);

            }


            pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[Posicao.Linha, Posicao.Coluna] = true;
                if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);

            }


            pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[Posicao.Linha, Posicao.Coluna] = true;
                if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna -1);

            }

            return mat;
        }
    }
}
