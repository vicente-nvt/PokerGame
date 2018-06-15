using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using Xunit;

namespace PokerGame.Testes
{
    public class UmParDeCartasTeste
    {

        private readonly List<Carta> _maoDe5Cartas;

        public UmParDeCartasTeste()
        {
            _maoDe5Cartas = new List<Carta>()
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).ComNaipe(Naipes.Copas).Construir()
            };
        }

        [Fact]
        public void DeveEncontrarUmParDeCartasNaMao()
        {
            var parEsperado = new string[] { "7.Espadas", "7.Ouros" };

            var parEncontrado = new UmParDeCartas(_maoDe5Cartas).Encontrar().Select(carta => carta.HashDaCarta);

            Assert.Equal(parEsperado, parEncontrado);
        }

        [Fact]
        public void DeveVerificarSeAJogadaFoiEncontradaNaMao()
        {
            var jogadaEncontradaNaMao = new UmParDeCartas(_maoDe5Cartas).JogadaEncontradaNaMao();

            Assert.True(jogadaEncontradaNaMao);
        }
    }
}
