using xadrez;
using tabuleiro;

namespace ConsoleChess
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));

                tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(4, 4));
                tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(2, 4));

                Tela.ImprimirTabuleiro(tab);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
