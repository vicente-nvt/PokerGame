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
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(14).ComNaipe(Naipes.Copas).Construir()
            };
            var identificadorDeTresCartasComValoresIguais = new IdentificaTresCartasComValoresIguais();
            _umaTrinca = new UmaTrinca(identificadorDeTresCartasComValoresIguais);
        }

        [Fact]
        public void DeveEncontrarUmaTrincaNaMao()
        {
            var trincaEsperada = new List<string>
            {
                "5.Paus",
                "5.Copas",
                "5.Ouros"
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
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Copas).Construir();

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
