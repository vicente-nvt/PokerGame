using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;
using Xunit;

namespace PokerGame.Testes.Jogadas
{
    public class StraightFlushTeste
    {
        private readonly List<Carta> _maoDe5Cartas;
        private readonly IJogada _straightFlush;

        public StraightFlushTeste()
        {            
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Hearts).Construir(),
            };

            var identificadorDeNaipesIguais = new IdentificaCincoCartasComNaipesIguais();
            var identificadorDeSequencia = new IdentificaSequenciaDeCarta();
            _straightFlush = new StraightFlush(identificadorDeNaipesIguais, identificadorDeSequencia);
        }

        [Fact]
        public void DeveEncontrarUmStraightFlushNaMao()
        {
            var straightFlushEsperado = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Hearts).Construir(),
            }.Select(carta => carta.HashDaCarta).ToList();

            var straightFlushEncontrado = _straightFlush.Encontrar(_maoDe5Cartas).Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(straightFlushEsperado, straightFlushEncontrado);
        }

        [Fact]
        public void DeveEncontrarAJogadaNaMao()
        {
            var jogadaEncontradaNaMao = _straightFlush.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoQuandoASequenciaEstiverQuebrada()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Hearts).Construir();

            var jogadaEncontradaNaMao = _straightFlush.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.False(jogadaEncontradaNaMao);
        }

        [Fact]
        public void DeveInformarPontuacaoDaJogadaCorretamente()
        {
            const double pontuacaoEsperada = 108;

            double pontuacaoEncontrada = _straightFlush.PontuacaoDaJogada;

            Assert.Equal(pontuacaoEsperada, pontuacaoEncontrada);
        }
    }
}
