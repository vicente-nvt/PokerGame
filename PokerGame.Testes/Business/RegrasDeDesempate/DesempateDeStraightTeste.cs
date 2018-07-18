using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Business.RegrasDeDesempate;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Business.RegrasDeDesempate
{
    public class DesempateDeStraightTeste
    {
        private readonly IIDentificadorDeCartas _identificadorDeCartaMaisAlta;
        private List<Carta> _maoA;
        private readonly List<Carta> _maoB;

        public DesempateDeStraightTeste()
        {
            _identificadorDeCartaMaisAlta = new IdentificaCartaMaisAlta();
            _maoA = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Spades).Construir()
            };
            _maoB = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Hearts).Construir()
            };

        }
        [Fact]
        public void DeveDesempatarEntreDoisStraightsDiferentes()
        {
            var maoVencedoraEsperada = _maoB.Select(carta => carta.HashDaCarta).ToList();

            var maoVencedoraEncontrada = new DesempateDeStraight(_identificadorDeCartaMaisAlta)
                .Desempatar(_maoA, _maoB).Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(maoVencedoraEsperada, maoVencedoraEncontrada);
        }

        [Fact]
        public void NaoDeveDesempatarEntreDoisStraightsIguais()
        {
            _maoA = _maoB.Select(carta => carta).ToList();

            var maoVencedoraEncontrada = new DesempateDeStraight(_identificadorDeCartaMaisAlta)
                .Desempatar(_maoA, _maoB).Select(carta => carta.HashDaCarta).ToList();

            Assert.Empty(maoVencedoraEncontrada);
        }
    }
}
