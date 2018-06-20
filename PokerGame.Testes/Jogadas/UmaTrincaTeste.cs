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
        private IList<Carta> _maoDe5Cartas;
        private IIDentificadorDeCartas _identificadorDeTresCartasComValoresIguais;

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
            _identificadorDeTresCartasComValoresIguais = new IdentificaTresCartasComValoresIguais();
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

            var trincaEncontrada = new UmaTrinca(_maoDe5Cartas, _identificadorDeTresCartasComValoresIguais).Encontrar().Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(trincaEsperada, trincaEncontrada);
        }

        [Fact]
        public void DeveVerificarSeAJogadaFoiEncontradaNaMao()
        {
            var jogadaEncontradaNaMao = new UmaTrinca(_maoDe5Cartas, _identificadorDeTresCartasComValoresIguais).JogadaEncontradaNaMao();

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSeNaoHouverTrinca()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Copas).Construir();

            var jogadaEncontradaNaMao = new UmaTrinca(_maoDe5Cartas, _identificadorDeTresCartasComValoresIguais).JogadaEncontradaNaMao();

            Assert.False(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSeAsOutrasDuasCartasForemIguais()
        {
            _maoDe5Cartas[4] = CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Copas).Construir();

            var jogadaEncontradaNaMao = new UmaTrinca(_maoDe5Cartas, _identificadorDeTresCartasComValoresIguais).JogadaEncontradaNaMao();

            Assert.False(jogadaEncontradaNaMao);
        }
    }
}
