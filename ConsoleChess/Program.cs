using ConsoleChess.xadrez;
using tabuleiro;

namespace ConsoleChess
{
    public class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez pos = new PosicaoXadrez('a', 1);
            Console.WriteLine(pos.ToPosicao());
            Console.WriteLine(pos);
        }
    }
}
