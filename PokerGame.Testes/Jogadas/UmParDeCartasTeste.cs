using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;
using Xunit;

namespace PokerGame.Testes.Jogadas
{
    public class UmParDeCartasTeste
    {

        private readonly List<Carta> _maoDe5Cartas;
        private readonly IIDentificadorDeCartas _identificadorDePar;

        public UmParDeCartasTeste()
        {
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).ComNaipe(Naipes.Copas).Construir()
            };
            _identificadorDePar = new IdentificaDuasCartasComValoresIguais();
        }

        [Fact]
        public void DeveEncontrarUmParDeCartasNaMao()
        {
            var parEsperado = new[] { "7.Espadas", "7.Ouros" };

            var parEncontrado = new UmParDeCartas(_identificadorDePar).Encontrar(_maoDe5Cartas)
                .Select(carta => carta.HashDaCarta);

            Assert.Equal(parEsperado, parEncontrado);
        }

        [Fact]
        public void DeveVerificarSeAJogadaFoiEncontradaNaMao()
        {
            var jogadaEncontradaNaMao = new UmParDeCartas(_identificadorDePar).JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSeNaoHouverUmPar()
        {
            _maoDe5Cartas[3] = CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Ouros).Construir();

            var jogadaEncontradaNaMao = new UmParDeCartas(_identificadorDePar).JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.False(jogadaEncontradaNaMao);
        }
    }
}
