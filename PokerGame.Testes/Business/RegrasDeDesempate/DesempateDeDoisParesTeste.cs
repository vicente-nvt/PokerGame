using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Business.RegrasDeDesempate;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Business.RegrasDeDesempate
{
    public class DesempateDeDoisParesTeste
    {
        private readonly IIDentificadorDeCartas _identificadorDePar;
        private List<Carta> _maoA;
        private readonly List<Carta> _maoB;

        public DesempateDeDoisParesTeste()
        {
            _identificadorDePar = new IdentificaDuasCartasComValoresIguais();
            _maoA = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Spades).Construir()
            };
            _maoB = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Spades).Construir()
            };
        }

        [Fact]
        public void DeveDesempatarEntreDoisParesDiferentesComParesDiferentes()
        {
            var jogadaVencedoraEsperada = _maoB.Select(carta => carta.HashDaCarta).ToList();
            
            var jogadaVencedoraEncontrada = new DesempateDeDoisPares(_identificadorDePar)
                .Desempatar(_maoA, _maoB).Select(carta => carta.HashDaCarta).ToList();
            
            Assert.Equal(jogadaVencedoraEsperada, jogadaVencedoraEncontrada);
        }

        [Fact]
        public void DeveDesempatarEntreDoisParesDiferentesComParMaiorIgual()
        {
            _maoA[3] = CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Hearts).Construir();
            var jogadaVencedoraEsperada = _maoB.Select(carta => carta.HashDaCarta).ToList();

            var jogadaVencedoraEncontrada = new DesempateDeDoisPares(_identificadorDePar)
                .Desempatar(_maoA, _maoB).Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(jogadaVencedoraEsperada, jogadaVencedoraEncontrada);
        }

        [Fact]
        public void DeveDesempatarEntreDoisParesDiferentesComParesIguais()
        {
            _maoA = _maoB.Select(carta => carta).ToList();
            _maoB[4] = CartaBuilder.UmaCarta().ComValor(14).ComNaipe(Naipes.Hearts).Construir();
            var jogadaVencedoraEsperada = _maoB.Select(carta => carta.HashDaCarta).ToList();

            var jogadaVencedoraEncontrada = new DesempateDeDoisPares(_identificadorDePar)
                .Desempatar(_maoA, _maoB).Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(jogadaVencedoraEsperada, jogadaVencedoraEncontrada);
        }
    }
}
