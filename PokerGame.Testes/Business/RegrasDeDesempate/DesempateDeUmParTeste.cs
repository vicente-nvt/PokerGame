using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Business.RegrasDeDesempate;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Business.RegrasDeDesempate
{
    public class DesempateDeUmParTeste
    {
        private List<Carta> _maoA;
        private List<Carta> _maoB;
        private readonly DesempateDeUmPar _desempateDeUmPar;

        public DesempateDeUmParTeste()
        {
            var identificadorDePar = new IdentificaDuasCartasComValoresIguais();
            var identificadorDeCartaMaisAlta = new IdentificaCartaMaisAlta();
            _maoA = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).ComNaipe(Naipes.Hearts).Construir(),
            };
            _maoB = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Hearts).Construir(),
            };
            _desempateDeUmPar = new DesempateDeUmPar(identificadorDePar, identificadorDeCartaMaisAlta);
        }

        [Fact]
        public void DeveDesempatarEntreDoisParesDiferentes()
        {
            var maoVencedoraEsperada = _maoA.Select(carta => carta.HashDaCarta).ToList();
            
            var maoVencedoraEncontrada = _desempateDeUmPar.Desempatar(_maoA, _maoB)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(maoVencedoraEsperada, maoVencedoraEncontrada);
        }

        [Fact]
        public void DeveDesempatarEntreDoisParesIguais()
        {
            _maoA = _maoB.Select(carta => carta).ToList();
            _maoA[4] = CartaBuilder.UmaCarta().ComValor(12).ComNaipe(Naipes.Hearts).Construir();

            var maoVencedoraEsperada = _maoA.Select(carta => carta.HashDaCarta).ToList();

            var maoVencedoraEncontrada = _desempateDeUmPar.Desempatar(_maoA, _maoB)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(maoVencedoraEsperada, maoVencedoraEncontrada);
        }

        [Fact]
        public void NaoDeveEncontrarVencedorEntreDuasMaosIguais()
        {
            _maoB = _maoA.Select(carta => carta).ToList();

            var maoVencedoraEncontrada = _desempateDeUmPar.Desempatar(_maoA, _maoB);


            Assert.Empty(maoVencedoraEncontrada);
        }
    }
}