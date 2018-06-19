using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using Xunit;

//Straight flush - todas as cartas são consecutivas e do mesmo naipe;

namespace PokerGame.Testes.Jogadas
{
    public class StraightFlushTeste
    {
        private List<Carta> _maoDe5Cartas;
        private IdentificaSequenciaDeCarta _identificadorDeSequencia;
        private IIDentificadorDeCartas _identificadorDeNaipesIguais;

        public StraightFlushTeste()
        {            
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Copas).Construir(),
            };

            _identificadorDeNaipesIguais = new IdentificaCincoCartasComNaipesIguais();
            _identificadorDeSequencia = new IdentificaSequenciaDeCarta();
        }

        [Fact]
        public void DeveEncontrarUmStraightFlushNaMao()
        {
            var straightFlushEsperado = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Copas).Construir(),
            }.Select(carta => carta.HashDaCarta).ToList();

            var straightFlushEncontrado =
                new StraightFlush(_maoDe5Cartas, _identificadorDeNaipesIguais, _identificadorDeSequencia).Encontrar()
                    .Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(straightFlushEsperado, straightFlushEncontrado);
        }

        [Fact]
        public void DeveEncontrarAJogadaNaMao()
        {
            var jogadaEncontradaNaMao =
                new StraightFlush(_maoDe5Cartas, _identificadorDeNaipesIguais, _identificadorDeSequencia)
                    .JogadaEncontradaNaMao();

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoQuandoASequenciaEstiverQuebrada()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Copas).Construir();

            var jogadaEncontradaNaMao =
                new StraightFlush(_maoDe5Cartas, _identificadorDeNaipesIguais, _identificadorDeSequencia)
                    .JogadaEncontradaNaMao();

            Assert.False(jogadaEncontradaNaMao);
        }
    }
}
