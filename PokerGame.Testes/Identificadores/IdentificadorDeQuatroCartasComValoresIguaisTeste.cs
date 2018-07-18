using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Identificadores
{
    public class IdentificadorDeQuatroCartasComValoresIguaisTeste
    {
        private readonly IList<Carta> _listaDeCartas;

        public IdentificadorDeQuatroCartasComValoresIguaisTeste()
        {
            _listaDeCartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Hearts).Construir()
            };
        }

        [Fact]
        public void DeveIdentificarQuatroCartasComValorIgual()
        {
            var quatroCartasEsperadas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Clubs).Construir()
            }.Select(carta => carta.Valor).ToList();

            var quatroCartasEncontradas = new IdentificaQuatroCartasComValoresIguais().IdentificarCartas(_listaDeCartas).
                Select(carta => carta.Valor).ToList();
            
            Assert.Equal(quatroCartasEsperadas, quatroCartasEncontradas);
        }

        [Fact]
        public void NaoDeveIdentificarSeNaoHouverQuatroCartasComValorIgual()
        {
            _listaDeCartas[0] = CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Spades).Construir();

            var quadraEncontrada = new IdentificaQuatroCartasComValoresIguais().IdentificarCartas(_listaDeCartas);

            Assert.Empty(quadraEncontrada);
        }
    }
}
