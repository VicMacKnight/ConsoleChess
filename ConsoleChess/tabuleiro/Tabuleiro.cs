using ConsoleChess.tabuleiro;

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
    }
}
