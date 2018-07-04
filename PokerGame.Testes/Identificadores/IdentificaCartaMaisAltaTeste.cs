using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Identificadores
{
    public class IdentificaCartaMaisAltaTeste
    {
        private readonly List<Carta> _listaDeCartas;

        public IdentificaCartaMaisAltaTeste()
        {
            _listaDeCartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Copas).Construir()
            };
        }

        [Fact]
        public void DeveEncontrarACartaMaisAlta()
        {
            var cartaEsperada = CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Copas).Construir();

            var cartaEncontrada = new IdentificaCartaMaisAlta().IdentificarCartas(_listaDeCartas).First();

            Assert.Equal(cartaEsperada.Valor, cartaEncontrada.Valor);
        }
    }
}
