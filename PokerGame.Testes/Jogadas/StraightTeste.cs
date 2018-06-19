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

            _identificadorDeSequencia = new IdentificaSequenciaDeCarta();
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

            var straightEncontrado = new Straight(_maoDe5Cartas, _identificadorDeSequencia).Encontrar().Select(carta => carta.HashDaCarta).ToList();
            
            Assert.Equal(straightEsperado, straightEncontrado);
        }

        [Fact]
        public void DeveVerificarSeEncontrouAJogadaNaMao()
        {
            var jogadaEncontradaNaMao = new Straight(_maoDe5Cartas, _identificadorDeSequencia).JogadaEncontradaNaMao();

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSeNaoForUmaSequencia()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Copas).Construir();

            var jogadaEncontradaNaMao = new Straight(_maoDe5Cartas, _identificadorDeSequencia).JogadaEncontradaNaMao();

            Assert.False(jogadaEncontradaNaMao);
        }
    }
}
