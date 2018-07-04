using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;
using Xunit;

namespace PokerGame.Testes.Jogadas
{
    public class DoisParesDiferentesTeste
    {
        private readonly List<Carta> _maoDe5Cartas;        
        private readonly IJogada _doisParesDiferentes;

        public DoisParesDiferentesTeste()
        {
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).ComNaipe(Naipes.Copas).Construir()
            };
            var identificadorDePar = new IdentificaDuasCartasComValoresIguais();
            _doisParesDiferentes = new DoisParesDiferentes(identificadorDePar);
        }
        [Fact]
        public void DeveEncontrarDoisParesDiferentesNaMao()
        {
            var doisParesEsperados = new List<string> { "5.Espadas", "5.Ouros", "9.Paus", "9.Copas" };            

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
            _maoDe5Cartas[1] = CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Copas).Construir();

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
