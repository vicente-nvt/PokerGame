using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Identificadores
{
    public class IdentificaDuasCartasComValoresIguaisTeste
    {
        private readonly List<Carta> _listaDeCartas;
        private readonly List<Carta> _duasCartasEsperadas;

        public IdentificaDuasCartasComValoresIguaisTeste()
        {
            _listaDeCartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Diamonds).Construir()
            };

            _duasCartasEsperadas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Diamonds).Construir()                
            };
        }

        [Fact]
        public void DeveEncontrarDuasCartasIguais()
        {
            var duasCartasEsperadas = _duasCartasEsperadas.Select(carta => carta.HashDaCarta).ToList();

            var tresCartasEncontradas = new IdentificaDuasCartasComValoresIguais().IdentificarCartas(_listaDeCartas)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(duasCartasEsperadas, tresCartasEncontradas);
        }

        [Fact]
        public void NaoDeveEncontrarDuasCartasIguais()
        {
            _listaDeCartas[0] = CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Diamonds).Construir();
            var duasCartasEsperadas = _duasCartasEsperadas.Select(carta => carta.HashDaCarta).ToList();

            var duasCartasEncontradas = new IdentificaDuasCartasComValoresIguais().IdentificarCartas(_listaDeCartas)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.NotEqual(duasCartasEsperadas, duasCartasEncontradas);
        }
    }
}
