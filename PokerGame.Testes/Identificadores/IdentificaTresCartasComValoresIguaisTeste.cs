using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Identificadores
{
    public class IdentificaTresCartasComValoresIguaisTeste
    {
        private readonly IList<Carta> _listaDeCartas;
        private readonly List<Carta> _tresCartasEsperadas;

        public IdentificaTresCartasComValoresIguaisTeste()
        {
            _listaDeCartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Diamonds).Construir()
            };

            _tresCartasEsperadas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Diamonds).Construir()
            };
        }

        [Fact]
        public void DeveEncontrarTresCartasIguais()
        {
            var tresCartasEsperadas = _tresCartasEsperadas.Select(carta => carta.HashDaCarta).ToList();

            var tresCartasEncontradas = new IdentificaTresCartasComValoresIguais().IdentificarCartas(_listaDeCartas)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(tresCartasEsperadas, tresCartasEncontradas);
        }

        [Fact]
        public void NaoDeveEncontrarTresCartasIguais()
        {
            _listaDeCartas[0] = CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Diamonds).Construir();
            var tresCartasEsperadas = _tresCartasEsperadas.Select(carta => carta.HashDaCarta).ToList();

            var tresCartasEncontradas = new IdentificaTresCartasComValoresIguais().IdentificarCartas(_listaDeCartas)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.NotEqual(tresCartasEsperadas, tresCartasEncontradas);
        }
    }
}

