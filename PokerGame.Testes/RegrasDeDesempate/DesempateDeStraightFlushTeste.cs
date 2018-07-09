using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.RegrasDeDesempate;
using Xunit;

namespace PokerGame.Testes.RegrasDeDesempate
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
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Ouros).Construir()
            };
            _maoB = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Paus).Construir()
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
