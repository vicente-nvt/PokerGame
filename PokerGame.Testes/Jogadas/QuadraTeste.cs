using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Jogadas;
using Xunit;

namespace PokerGame.Testes.Jogadas
{
    public class QuadraTeste
    {
        private readonly List<Carta> _maoDe5Cartas;

        public QuadraTeste()
        {
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Ouros).Construir()
            };
        }

        [Fact]
        public void DeveEncontrarUmaQuadraNaMao()
        {
            var quadraEsperada = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Copas).Construir(),
            }.Select(carta => carta.HashDaCarta).ToList();

            var quadraEncontrada = new Quadra().Encontrar(_maoDe5Cartas).Select(carta => carta.HashDaCarta).ToList();
            
            Assert.Equal(quadraEsperada, quadraEncontrada);
        }

        [Fact]
        public void DeveEncontrarAJogadaNaMao()
        {
            var jogadaEncontradaNaMao = new Quadra().JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSeNaoHouverUmaQuadra()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(14).ComNaipe(Naipes.Ouros).Construir();

            var jogadaEncontradaNaMao = new Quadra().JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.False(jogadaEncontradaNaMao);
        }
    }
}
