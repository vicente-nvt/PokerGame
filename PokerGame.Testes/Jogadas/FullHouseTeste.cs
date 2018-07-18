using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;
using Xunit;

namespace PokerGame.Testes.Jogadas
{
    public class FullHouseTeste
    {
        private readonly List<Carta> _maoDe5Cartas;
        private readonly IJogada _fullHouse;

        public FullHouseTeste()
        {
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Clubs).Construir()
            };

            var identificadorDePar = new IdentificaDuasCartasComValoresIguais();
            var identificadorDeTrinca = new IdentificaTresCartasComValoresIguais();
            _fullHouse = new FullHouse(identificadorDeTrinca, identificadorDePar);
        }

        [Fact]
        public void DeveEncontrarUmFullHouseNaMao()
        {
            var fullHouseEsperado = new List<string> {"1.Hearts", "1.Diamonds", "1.Spades", "2.Spades", "2.Clubs"};

            var fullHouseEncontrado = _fullHouse.Encontrar(_maoDe5Cartas).Select(carta => carta.HashDaCarta).ToList();
            
            Assert.Equal(fullHouseEsperado, fullHouseEncontrado);
        }

        [Fact]
        public void DeveEncontrarAJogadaNaMao()
        {
            var jogadaEncontradaNaMao = _fullHouse.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoQuandoNaoTiverUmaTrinca()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Hearts).Construir();

            var jogadaEncontradaNaMao = _fullHouse.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.False(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoQuandoNaoTiverUmPar()
        {
            _maoDe5Cartas[1] = CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Hearts).Construir();

            var jogadaEncontradaNaMao = _fullHouse.JogadaEncontradaNaMao(_maoDe5Cartas); 

            Assert.False(jogadaEncontradaNaMao);
        }

        [Fact]
        public void DeveInformarPontuacaoDaJogadaCorretamente()
        {
            const double pontuacaoEsperada = 106;

            double pontuacaoEncontrada = _fullHouse.PontuacaoDaJogada;

            Assert.Equal(pontuacaoEsperada, pontuacaoEncontrada);
        }
    }
}
