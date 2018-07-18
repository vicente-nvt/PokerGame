using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Business.RegrasDeDesempate;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Business.RegrasDeDesempate
{
    public class DesempateDeStraightFlushTeste
    {
        private readonly IRegraDeDesempate _desempateDeStraightFlush;
        private List<Carta> _maoA;
        private readonly List<Carta> _maoB;

        public DesempateDeStraightFlushTeste()
        {
            var identificadorDeCartaMaisAlta = new IdentificaCartaMaisAlta();
            _desempateDeStraightFlush = new DesempateDeStraightFlush(identificadorDeCartaMaisAlta);

            _maoA = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Diamonds).Construir()
            };
            _maoB = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Clubs).Construir()
            };
        }

        [Fact]
        public void DeveDesempatarEntreDoisStraightFlush()
        {
            var maoVencedoraEsperada = _maoB.Select(carta => carta.HashDaCarta).ToList();

            var maoVencedoraEncontrada = _desempateDeStraightFlush.Desempatar(_maoA, _maoB)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(maoVencedoraEsperada, maoVencedoraEncontrada);
        }

        [Fact]
        public void NaoDeveDeterminarVencedorEmCasoDeMaosIguais()
        {
            _maoA = _maoB.Select(carta => carta).ToList();

            var maoVencedoraEncontrada = _desempateDeStraightFlush.Desempatar(_maoA, _maoB)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.Empty(maoVencedoraEncontrada);
        }
    }
}
