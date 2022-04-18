using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base (tabuleiro, cor)
        {

        }
        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = Tabuleiro.peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.NumeroLinhas, Tabuleiro.NumeroColunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //diagonal direita acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna +1);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna +1);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //diagonal direita abaixo
            pos.DefinirValores(Posicao.Linha +1, Posicao.Coluna + 1);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //abaixo
            pos.DefinirValores(Posicao.Linha +1, Posicao.Coluna);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //diagonal esquerda abaixo
            pos.DefinirValores(Posicao.Linha +1, Posicao.Coluna -1);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna -1);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //diagonal direita acima
            pos.DefinirValores(Posicao.Linha -1, Posicao.Coluna -1);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}
