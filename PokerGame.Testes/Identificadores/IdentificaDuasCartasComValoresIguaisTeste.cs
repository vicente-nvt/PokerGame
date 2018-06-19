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
        private List<Carta> _listaDeCartas;
        private List<Carta> _duasCartasEsperadas;

        public IdentificaDuasCartasComValoresIguaisTeste()
        {
            _listaDeCartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Ouros).Construir()
            };

            _duasCartasEsperadas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Ouros).Construir()                
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
            _listaDeCartas[0] = CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Ouros).Construir();
            var duasCartasEsperadas = _duasCartasEsperadas.Select(carta => carta.HashDaCarta).ToList();

            var duasCartasEncontradas = new IdentificaDuasCartasComValoresIguais().IdentificarCartas(_listaDeCartas)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.NotEqual(duasCartasEsperadas, duasCartasEncontradas);
        }
    }
}
