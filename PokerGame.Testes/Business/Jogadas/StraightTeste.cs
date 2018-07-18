using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Business.Jogadas;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Business.Jogadas
{
    public class StraightTeste
    {
        private readonly List<Carta> _maoDe5Cartas;
        private readonly IJogada _straight;

        public StraightTeste()
        {       
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Clubs).Construir() ,
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Clubs).Construir() ,
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Spades).Construir() ,
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Hearts).Construir() ,
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Diamonds).Construir()
            };

            var identificadorDeSequencia = new IdentificaSequenciaDeCarta();
            _straight = new Straight(identificadorDeSequencia);
        }

        [Fact]
        public void DeveEncontrarUmStraightNaMao()
        {
            var straightEsperado = new List<string>
            {
                "3.Clubs",
                "4.Hearts",
                "5.Spades",
                "6.Clubs",
                "7.Diamonds"
            };

            var straightEncontrado = _straight.Encontrar(_maoDe5Cartas)
                .Select(carta => carta.HashDaCarta).ToList();
            
            Assert.Equal(straightEsperado, straightEncontrado);
        }

        [Fact]
        public void DeveVerificarSeEncontrouAJogadaNaMao()
        {
            var jogadaEncontradaNaMao = _straight.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSeNaoForUmaSequencia()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Hearts).Construir();

            var jogadaEncontradaNaMao = _straight.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.False(jogadaEncontradaNaMao);
        }

        [Fact]
        public void DeveInformarPontuacaoDaJogadaCorretamente()
        {
            const double pontuacaoEsperada = 104;

            double pontuacaoEncontrada = _straight.PontuacaoDaJogada;

            Assert.Equal(pontuacaoEsperada, pontuacaoEncontrada);
        }
    }
}
