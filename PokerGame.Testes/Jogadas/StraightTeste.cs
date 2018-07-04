using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;
using Xunit;

namespace PokerGame.Testes.Jogadas
{
    public class StraightTeste
    {
        private List<Carta> _maoDe5Cartas;
        private IIDentificadorDeCartas _identificadorDeSequencia;
        private readonly IJogada _straight;

        public StraightTeste()
        {       
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Paus).Construir() ,
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Paus).Construir() ,
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Espadas).Construir() ,
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Copas).Construir() ,
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Ouros).Construir()
            };

            var identificadorDeSequencia = new IdentificaSequenciaDeCarta();
            _straight = new Straight(identificadorDeSequencia);
        }

        [Fact]
        public void DeveEncontrarUmStraightNaMao()
        {
            var straightEsperado = new List<string>
            {
                "3.Paus",
                "4.Copas",
                "5.Espadas",
                "6.Paus",
                "7.Ouros"
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
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Copas).Construir();

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
