using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;
using Xunit;

namespace PokerGame.Testes.Jogadas
{
    public class FlushTeste
    {
        private readonly List<Carta> _maoDe5Cartas;
        private readonly IIDentificadorDeCartas _identificardorDeCincoNaipesIguais;

        public FlushTeste()
        {
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(14).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(12).ComNaipe(Naipes.Copas).Construir()
            };

            _identificardorDeCincoNaipesIguais = new IdentificaCincoCartasComNaipesIguais();
            ;
        }

        [Fact]
        public void DeveEncontrarUmFlushNaMao()
        {
            var flushEsperado = new List<string> { "5.Copas", "8.Copas", "14.Copas", "10.Copas", "12.Copas" }.ToList();

            var flushEncontrado = new Flush(_identificardorDeCincoNaipesIguais).Encontrar(_maoDe5Cartas)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(flushEsperado, flushEncontrado);
        }

        [Fact]
        public void DeveVerificarSeEncontrouAJogadaNaMao()
        {
            var jogadaEncontradaNaMao =
                new Flush(_identificardorDeCincoNaipesIguais).JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSeAlgumaCartaForDeNaipeDiferente()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Ouros).Construir();

            var jogadaEncontradaNaMao =
                new Flush(_identificardorDeCincoNaipesIguais).JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.False(jogadaEncontradaNaMao);
        }
    }
}
