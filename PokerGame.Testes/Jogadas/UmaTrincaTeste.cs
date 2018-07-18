using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;
using Xunit;

namespace PokerGame.Testes.Jogadas
{
    public class UmaTrincaTeste
    {
        private readonly List<Carta> _maoDe5Cartas;
        private readonly IIDentificadorDeCartas _identificadorDeTresCartasComValoresIguais;
        private readonly IJogada _umaTrinca;

        public UmaTrincaTeste()
        {
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(14).ComNaipe(Naipes.Hearts).Construir()
            };
            var identificadorDeTresCartasComValoresIguais = new IdentificaTresCartasComValoresIguais();
            _umaTrinca = new UmaTrinca(identificadorDeTresCartasComValoresIguais);
        }

        [Fact]
        public void DeveEncontrarUmaTrincaNaMao()
        {
            var trincaEsperada = new List<string>
            {
                "5.Clubs",
                "5.Hearts",
                "5.Diamonds"
            };

            var trincaEncontrada = _umaTrinca.Encontrar(_maoDe5Cartas).Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(trincaEsperada, trincaEncontrada);
        }

        [Fact]
        public void DeveVerificarSeAJogadaFoiEncontradaNaMao()
        {
            var jogadaEncontradaNaMao = _umaTrinca.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSeNaoHouverTrinca()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Hearts).Construir();

            var jogadaEncontradaNaMao = _umaTrinca.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.False(jogadaEncontradaNaMao);
        }

        [Fact]
        public void DeveInformarPontuacaoDaJogadaCorretamente()
        {
            const double pontuacaoEsperada = 103;

            double pontuacaoEncontrada = _umaTrinca.PontuacaoDaJogada;

            Assert.Equal(pontuacaoEsperada, pontuacaoEncontrada);
        }
    }
}
