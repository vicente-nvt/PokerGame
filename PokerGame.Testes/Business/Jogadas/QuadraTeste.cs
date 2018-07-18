using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Business.Jogadas;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Business.Jogadas
{
    public class QuadraTeste
    {
        private readonly List<Carta> _maoDe5Cartas;
        private readonly IJogada _quadra;

        public QuadraTeste()
        {
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Diamonds).Construir()
            };
            var identificadorDeQuatroCartasComValoresIguais = new IdentificaQuatroCartasComValoresIguais();
            _quadra = new Quadra(identificadorDeQuatroCartasComValoresIguais);            
        }

        [Fact]
        public void DeveEncontrarUmaQuadraNaMao()
        {
            var quadraEsperada = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Hearts).Construir(),
            }.Select(carta => carta.HashDaCarta).ToList();

            var quadraEncontrada = _quadra.Encontrar(_maoDe5Cartas).Select(carta => carta.HashDaCarta).ToList();
            
            Assert.Equal(quadraEsperada, quadraEncontrada);
        }

        [Fact]
        public void DeveEncontrarAJogadaNaMao()
        {
            var jogadaEncontradaNaMao = _quadra.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSeNaoHouverUmaQuadra()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(14).ComNaipe(Naipes.Diamonds).Construir();

            var jogadaEncontradaNaMao = _quadra.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.False(jogadaEncontradaNaMao);
        }

        [Fact]
        public void DeveInformarPontuacaoDaJogadaCorretamente()
        {
            const double pontuacaoEsperada = 107;

            double pontuacaoEncontrada = _quadra.PontuacaoDaJogada;

            Assert.Equal(pontuacaoEsperada, pontuacaoEncontrada);
        }
    }
}
