using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Business.RegrasDeDesempate;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Business.RegrasDeDesempate
{
    public class DesempateDeQuadraTeste
    {
        [Fact]
        public void DeveDesempatarEntreDuasQuadras()
        {
            var identificadorDeQuadra = new IdentificaQuatroCartasComValoresIguais();
            var maoA = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Diamonds).Construir()
            };
            var maoB = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Diamonds).Construir()
            };
            var maoVencedoraEsperada = maoB.Select(carta => carta).ToList();
            
            var maoVencedoraEncontrada = new DesempateDeQuadra(identificadorDeQuadra).Desempatar(maoA, maoB);

            Assert.Equal(maoVencedoraEsperada, maoVencedoraEncontrada);
        }
    }
}
