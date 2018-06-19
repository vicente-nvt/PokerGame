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
        private IList<Carta> _listaDeCartas;
        private List<Carta> _tresCartasEsperadas;

        public IdentificaTresCartasComValoresIguaisTeste()
        {
            _listaDeCartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Ouros).Construir()
            };

            _tresCartasEsperadas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Ouros).Construir()
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
            _listaDeCartas[0] = CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Ouros).Construir();
            var tresCartasEsperadas = _tresCartasEsperadas.Select(carta => carta.HashDaCarta).ToList();

            var tresCartasEncontradas = new IdentificaTresCartasComValoresIguais().IdentificarCartas(_listaDeCartas)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.NotEqual(tresCartasEsperadas, tresCartasEncontradas);
        }
    }
}

