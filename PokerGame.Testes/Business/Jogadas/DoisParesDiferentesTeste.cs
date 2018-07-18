using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Business.Jogadas;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Business.Jogadas
{
    public class DoisParesDiferentesTeste
    {
        private readonly List<Carta> _maoDe5Cartas;        
        private readonly IJogada _doisParesDiferentes;

        public DoisParesDiferentesTeste()
        {
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).ComNaipe(Naipes.Hearts).Construir()
            };
            var identificadorDePar = new IdentificaDuasCartasComValoresIguais();
            _doisParesDiferentes = new DoisParesDiferentes(identificadorDePar);
        }
        [Fact]
        public void DeveEncontrarDoisParesDiferentesNaMao()
        {
            var doisParesEsperados = new List<string> { "5.Spades", "5.Diamonds", "9.Clubs", "9.Hearts" };            

            var doisParesEncontrados = _doisParesDiferentes.Encontrar(_maoDe5Cartas)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(doisParesEsperados, doisParesEncontrados);
        }

        [Fact]
        public void DeveEncontrarAJogadaNaMao()
        {
            var jogadaEncontradaNaMao = _doisParesDiferentes.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSeNaoHouverDoisPares()
        {
            _maoDe5Cartas[1] = CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Hearts).Construir();

            var jogadaEncontradaNaMao =
                _doisParesDiferentes.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.False(jogadaEncontradaNaMao);
        }

        [Fact]
        public void DeveInformarPontuacaoDaJogadaCorretamente()
        {
            const double pontuacaoEsperada = 102;

            double pontuacaoEncontrada = _doisParesDiferentes.PontuacaoDaJogada;

            Assert.Equal(pontuacaoEsperada, pontuacaoEncontrada);
        }
    }
}
