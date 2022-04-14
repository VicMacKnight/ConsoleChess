namespace tabuleiro
{
    public class Tabuleiro
    {
        public int NumeroLinhas { get; set; }
        public int NumeroColunas { get; set; }
        private Peca[,] Peca;

        public Tabuleiro(int linhas, int colunas)
        {
            NumeroLinhas = linhas;
            NumeroColunas = colunas;
            Peca = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return Peca[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            return Peca[pos.Linha, pos.Coluna];
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            Peca[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca retirarPeca(Posicao posicao)
        {
            if (peca(posicao) == null)
            {
                return null;
            }
            Peca aux = peca(posicao);
            aux.Posicao = null;
            Peca[posicao.Linha, posicao.Coluna] = null;
            return aux;
        }

        public bool posicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= NumeroLinhas || pos.Coluna < 0 || pos.Coluna >= NumeroColunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição invalida!");
            }
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }
    }
}
