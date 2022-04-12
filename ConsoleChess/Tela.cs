using tabuleiro;

namespace ConsoleChess
{
    public class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for(int i = 0; i < tabuleiro.NumeroLinhas; i++)
            {
                for(int j = 0; j < tabuleiro.NumeroColunas; j++)
                {
                    if(tabuleiro.peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                    Console.Write( tabuleiro.peca(i,j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
