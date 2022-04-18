using tabuleiro;
using System.Collections.Generic;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; set; }
        public int turno;
        public Cor jogadorAtual;
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if (estaEmCheque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Voce nao pode se colocar em xeque!");
            }

            if (estaEmCheque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            turno++;
            mudaJogador();
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQteMovimentos();
            if (pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);
        }

        public void validarPosicaoDeOrigem(Posicao posicao)
        {
            if (tab.peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peca na posicao de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(posicao).Cor)
            {
                throw new TabuleiroException("A peca de origem escolhida nao eh sua");
            }
            if (!tab.peca(posicao).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não ha movimentos possiveis para a peca de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posicao de destino invalida!");
            }
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmCheque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Nao tem rei da cor " + cor + " no tabuleiro");
            }

            foreach (Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        private void colocarPecas()
        {
            colocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rainha(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Rei(tab, Cor.Branca));
            colocarNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));

            //tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('a', 1).ToPosicao());
            //tab.colocarPeca(new Cavalo(tab, Cor.Branca), new PosicaoXadrez('b', 1).ToPosicao());
            //tab.colocarPeca(new Bispo(tab, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            //tab.colocarPeca(new Rainha(tab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());
            //tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            //tab.colocarPeca(new Bispo(tab, Cor.Branca), new PosicaoXadrez('f', 1).ToPosicao());
            //tab.colocarPeca(new Cavalo(tab, Cor.Branca), new PosicaoXadrez('g', 1).ToPosicao());
            //tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('h', 1).ToPosicao());

            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('a', 8).ToPosicao());
            tab.colocarPeca(new Cavalo(tab, Cor.Preta), new PosicaoXadrez('b', 8).ToPosicao());
            tab.colocarPeca(new Bispo(tab, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            tab.colocarPeca(new Rainha(tab, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            tab.colocarPeca(new Bispo(tab, Cor.Preta), new PosicaoXadrez('f', 8).ToPosicao());
            tab.colocarPeca(new Cavalo(tab, Cor.Preta), new PosicaoXadrez('g', 8).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('h', 8).ToPosicao());

            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('a', 2).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('b', 2).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('f', 2).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('g', 2).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('h', 2).ToPosicao());

            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('a', 7).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('b', 7).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('f', 7).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('g', 7).ToPosicao());
            tab.colocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('h', 7).ToPosicao());
        }
    }
}
