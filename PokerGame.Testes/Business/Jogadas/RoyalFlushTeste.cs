using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Business.Jogadas;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Business.Jogadas
{
    public class RoyalFlushTeste
    {
        private readonly List<Carta> _maoDe5Cartas;
        private readonly IJogada _royalFlush;

        public RoyalFlushTeste()
        {            
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(13).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(11).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(14).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(12).ComNaipe(Naipes.Hearts).Construir()
            };

            var identificadorDeSequencia = new IdentificaSequenciaDeCarta();
            var identificadorDeNaipesIguais = new IdentificaCincoCartasComNaipesIguais();
            _royalFlush = new RoyalFlush(identificadorDeSequencia, identificadorDeNaipesIguais);
        }

        [Fact]
        public void DeveEncontrarUmRoyalFlushNaMao()
        {
            var royalFlushEsperado = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(11).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(12).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(13).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(14).ComNaipe(Naipes.Hearts).Construir()
            }.Select(carta => carta.HashDaCarta).ToList();

            var royalFlushEncontrado = _royalFlush.Encontrar(_maoDe5Cartas).Select(carta => carta.HashDaCarta).ToList();
            
            Assert.Equal(royalFlushEsperado, royalFlushEncontrado);
        }

        [Fact]
        public void DeveEncontrarAJogadaNaMao()
        {
            var jogadaEncontradaNaMao = _royalFlush.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSeASequenciaEstiverQuebrada()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Hearts).Construir();

            var jogadaEncontradaNaMao = _royalFlush.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.False(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSePeloMenosUmNaipeForDiferentes()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(13).ComNaipe(Naipes.Diamonds).Construir();

            var jogadaEncontradaNaMao = _royalFlush.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.False(jogadaEncontradaNaMao);
        }

        [Fact]
        public void DeveInformarPontuacaoDaJogadaCorretamente()
        {
            const double pontuacaoEsperada = 109;

            double pontuacaoEncontrada = _royalFlush.PontuacaoDaJogada;

            Assert.Equal(pontuacaoEsperada, pontuacaoEncontrada);
        }
    }
}
