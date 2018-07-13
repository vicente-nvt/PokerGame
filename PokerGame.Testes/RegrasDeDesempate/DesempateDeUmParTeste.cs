using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.RegrasDeDesempate;
using Xunit;

namespace PokerGame.Testes.RegrasDeDesempate
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
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).ComNaipe(Naipes.Copas).Construir(),
            };
            _maoB = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Copas).Construir(),
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
            _maoA[4] = CartaBuilder.UmaCarta().ComValor(12).ComNaipe(Naipes.Copas).Construir();

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