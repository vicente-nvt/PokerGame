using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.RegrasDeDesempate;
using Xunit;

namespace PokerGame.Testes.RegrasDeDesempate
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
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Espadas).Construir()
            };
            _maoB = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Copas).Construir()
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
