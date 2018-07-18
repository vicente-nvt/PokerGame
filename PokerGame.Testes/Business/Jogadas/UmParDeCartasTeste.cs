using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Business.Jogadas;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Business.Jogadas
{
    public class UmParDeCartasTeste
    {

        private readonly List<Carta> _maoDe5Cartas;
        private readonly IJogada _umParDeCartas;

        public UmParDeCartasTeste()
        {
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).ComNaipe(Naipes.Hearts).Construir()
            };
            var identificadorDePar = new IdentificaDuasCartasComValoresIguais();
            _umParDeCartas = new UmParDeCartas(identificadorDePar);
        }

        [Fact]
        public void DeveEncontrarUmParDeCartasNaMao()
        {
            var parEsperado = new[] { "7.Spades", "7.Diamonds" };

            var parEncontrado = _umParDeCartas.Encontrar(_maoDe5Cartas)
                .Select(carta => carta.HashDaCarta);

            Assert.Equal(parEsperado, parEncontrado);
        }

        [Fact]
        public void DeveVerificarSeAJogadaFoiEncontradaNaMao()
        {
            var jogadaEncontradaNaMao = _umParDeCartas.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSeNaoHouverUmPar()
        {
            _maoDe5Cartas[3] = CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Diamonds).Construir();

            var jogadaEncontradaNaMao = _umParDeCartas.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.False(jogadaEncontradaNaMao);
        }

        [Fact]
        public void DeveInformarPontuacaoDaJogadaCorretamente()
        {
            const double pontuacaoEsperada = 101;

            double pontuacaoEncontrada = _umParDeCartas.PontuacaoDaJogada;

            Assert.Equal(pontuacaoEsperada, pontuacaoEncontrada);
        }
    }
}