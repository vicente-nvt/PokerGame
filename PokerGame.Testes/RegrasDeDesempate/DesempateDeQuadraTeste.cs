using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.RegrasDeDesempate;
using Xunit;

namespace PokerGame.Testes.RegrasDeDesempate
{
    public class DesempateDeQuadraTeste
    {
        [Fact]
        public void DeveDesempatarEntreDuasQuadras()
        {
            var identificadorDeQuadra = new IdentificaQuatroCartasComValoresIguais();
            var maoA = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Ouros).Construir()
            };
            var maoB = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Ouros).Construir()
            };
            var maoVencedoraEsperada = maoB.Select(carta => carta).ToList();
            
            var maoVencedoraEncontrada = new DesempateDeQuadra(identificadorDeQuadra).Desempatar(maoA, maoB);

            Assert.Equal(maoVencedoraEsperada, maoVencedoraEncontrada);
        }
    }
}
